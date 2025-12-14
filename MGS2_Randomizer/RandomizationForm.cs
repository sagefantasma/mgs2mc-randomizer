using MGS2_Randomizer.Properties;
using Serilog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Deployment.Application;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MGS2_Randomizer.MGS2Randomizer;

namespace MGS2_Randomizer
{
    public partial class RandomizationForm : Form
    {
        private string _installLocation { get; set; }
        private string userDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        private string _logLocation { get; set; }
        public static ILogger _logger { get; private set; }
        private static string AppVersion { get; set; }
        private string InstallLocation
        {
            get { return _installLocation; }
            set { mgs2ExeTextBox.Text = value;
                _installLocation = value;
            }
        }
        private string _configLocation { get; } = "config.json";
        private System.Media.SoundPlayer waitingMusic = new System.Media.SoundPlayer("13 Electronica Emma.wav");
        private System.Media.SoundPlayer keptYouWaitingHuh = new System.Media.SoundPlayer("mgs2-snake-kept-you-waiting-huh.wav");
        private bool _loaded = false;

        private static void SetAppVersion()
        {
            if (ApplicationDeployment.IsNetworkDeployed)
            {
                AppVersion = ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
            }
            else
            {
                AppVersion = $"{Assembly.GetExecutingAssembly().GetName().Version}(portable)";
            }

            if (Settings.Default.LastVersion != AppVersion)
            {
                Settings.Default.ShowChangelog = "True";
                Settings.Default.LastVersion = AppVersion;
            }
        }

        private static void ShowChangelog()
        {
            string changelog = $"Most recent changes in v{AppVersion}:\r\n\r\n" +
                $" - Fixed several rare randomization issues with Card randomization. \r\n" +
                $" - Fixed duplicate spawns of some automatically awarded weapons. \r\n" +
                $" - Added an option to restrict Card 4 to Shell 2 to help prevent soft-locks.\r\n"+
                $" - Fixed an issue where automatically awarded weapons were never progressive. \r\n\r\n" +
                $"Recent-ish changes:\r\n\r\n" +
                $" - Fixed bugs with the Nikita spawning in soft-lock locations even with the Nikita soft-lock option enabled.\r\n" +
                $" - Fixed an issue where starting Plant items weren't being added to randomization pool when both Randomize Starting Items and Randomize Cards were active\r\n" +
                $" - Added new item models for B.D.U., phone, and M.O. Disk to help differentiate them.\r\n" +
                $" - Fixed bug with Cardboard Box 3 not getting textured correctly in Sea Dock.\r\n" +
                $" - Added guiderails to randomization form to help prevent undesired effects with guard value randomization.\r\n" +
                $" - Fixed several bugs causing progression-locks with the AK-74u, B.D.U, and Nikita.\r\n" +
                $" - Fixed an issue where randomized bombs on Strut F sometimes spawned incorrectly on higher difficulties.";

            MessageBox.Show(changelog, "MGS2 Randomizer Changelog", MessageBoxButtons.OK);
        }

        public RandomizationForm()
        {
            SetAppVersion();
            _logLocation = Path.Combine(userDocuments, "MGS2Randomizer.log");
            _logger = new LoggerConfiguration().WriteTo.File(_logLocation, rollOnFileSizeLimit: false, fileSizeLimitBytes: 50 * 1000 * 1000)
                .MinimumLevel.Is(Serilog.Events.LogEventLevel.Debug).CreateLogger();
            _logger.Information($"MGS2 Randomizer v.{AppVersion} initialized!");
            InitializeComponent();
            LoadConfig();
            SetupHelperButton();
            _loaded = true;
            if (Settings.Default.ShowChangelog == "True")
            {
                Settings.Default.ShowChangelog = "False";
                Settings.Default.Save();
                ShowChangelog();
            }
        }

        private void SetupHelperButton()
        {
            this.helpProvider1.SetShowHelp(this.randomizeSpawnsCheckbox, true);
            this.helpProvider1.SetHelpString(this.randomizeSpawnsCheckbox, "This option, when enabled, will cause spawned items/weapons/ammo to be randomized according to the options selected below in this group.");

            this.helpProvider1.SetShowHelp(this.seedAlwaysBeatableCheckbox, true);
            this.helpProvider1.SetHelpString(this.seedAlwaysBeatableCheckbox, "This option will make sure progressive weapons/items never spawn in an area you do not have access to.");

            this.helpProvider1.SetShowHelp(this.restrictNikitaCheckbox, true);
            this.helpProvider1.SetHelpString(this.restrictNikitaCheckbox, "This option will make sure the Nikita always spawns somewhere in Shell 2 before the Purification Chamber, so you don't get soft-locked if you missed it and 'Seed Always Beatable' is enabled.");

            this.helpProvider1.SetShowHelp(this.allWeaponsWillSpawnCheckbox, true);
            this.helpProvider1.SetHelpString(this.allWeaponsWillSpawnCheckbox, "This option will make sure weapons will not spawn in optional spawns, so you will have access to all of them throughout the game.");

            this.helpProvider1.SetShowHelp(this.randomizeRationsCheckbox, true);
            this.helpProvider1.SetHelpString(this.randomizeRationsCheckbox, "This will add Rations to the randomization pool. (If you are playing on Extreme or above: any item that is randomized into a position where a ration normally spawns WILL NOT SPAWN and RATIONS STILL WILL NOT SPAWN. Essentially, you just won't have nearly as much ammo as a normal run as progressive items will be unaffected.)");

            this.helpProvider1.SetShowHelp(this.randomizeStartingItemsCheckbox, true);
            this.helpProvider1.SetHelpString(this.randomizeStartingItemsCheckbox, "You will no longer be guaranteed M9, Camera, AP Sensor and Cigs on Tanker; nor AP Sensor and Binoculars on Plant.");

            this.helpProvider1.SetShowHelp(this.randomizeAutomaticRewardsCheckbox, true);
            this.helpProvider1.SetHelpString(this.randomizeAutomaticRewardsCheckbox, "Automatic rewards will be randomized into the pool. This includes: USP on Tanker; SOCOM, Coolant, Sensor A, Card Keys, BDU, Phone, and MO Disc on Plant.");

            this.helpProvider1.SetShowHelp(this.addCardsCheckbox, true);
            this.helpProvider1.SetHelpString(this.addCardsCheckbox, "If automatic rewards are enabled, you can enable this option to add cards to the randomization pool.");

            this.helpProvider1.SetShowHelp(this.restrictCard4CheckBox, true);
            this.helpProvider1.SetHelpString(this.restrictCard4CheckBox, "This option will make sure Card 4 always spawns somewhere in Shell 2 before the Purification Chamber, so you don't get soft-locked if you missed it and 'Seed Always Beatable' is enabled. (Card 5 is always on Shell 2 already)");

            this.helpProvider1.SetShowHelp(this.keepVanillaCardLevelsCheckbox, true);
            this.helpProvider1.SetHelpString(this.keepVanillaCardLevelsCheckbox, "If cards are in the randomization pool, you can enable this option to keep items at their 'native' spawn level. (AKS-74u will be behind a Lv2 door, PSG-1 will be behind a Lv3 door, etc...)");

            this.helpProvider1.SetShowHelp(this.randomizeBombLocations, true);
            this.helpProvider1.SetHelpString(this.randomizeBombLocations, "Randomize where all bombs during the bomb defusal segment spawn.");

            this.helpProvider1.SetShowHelp(this.randomizeEFConnectingBridgeClaymores, true);
            this.helpProvider1.SetHelpString(this.randomizeEFConnectingBridgeClaymores, "Randomize where the claymores spawn on the EF Connecting Bridge.");

            this.helpProvider1.SetShowHelp(this.randomizeTankerControlUnitLocations, true);
            this.helpProvider1.SetHelpString(this.randomizeTankerControlUnitLocations, "Randomize where control units spawn in the engine room on the Tanker.");

            this.helpProvider1.SetShowHelp(this.randomizeGuardValuesCheckBox, true);
            this.helpProvider1.SetHelpString(this.randomizeGuardValuesCheckBox, "Randomize guard vision ranges, hearing range, stun resistance, sleep duration, stun duration, etc.");

            this.helpProvider1.SetShowHelp(this.insanityScalarLabel, true);
            this.helpProvider1.SetHelpString(this.insanityScalarLabel, "Slide this to the left to have smaller randomized results, or to the right to have a larger range. Default position will have the closest values to \"standard\" for vision and hearing range.");
            this.helpProvider1.SetShowHelp(this.insanityScalarTrackBar, true);
            this.helpProvider1.SetHelpString(this.insanityScalarTrackBar, "Slide this to the left to have smaller randomized results, or to the right to have a larger range. Default position will have the closest values to \"standard\" for vision and hearing range.");

            this.helpProvider1.SetShowHelp(this.keepGuardValuesConsistentAcrossLevelsCheckbox, true);
            this.helpProvider1.SetHelpString(this.keepGuardValuesConsistentAcrossLevelsCheckbox, "If guard values are randomized, keep them consistent across all levels instead of differing with each level.");

            this.helpProvider1.SetShowHelp(this.randomizeGuardPatrolsCheckbox, true);
            this.helpProvider1.SetHelpString(this.randomizeGuardPatrolsCheckbox, "Randomize what patrol each guard follows, as well as what point in the patrol the guard starts at.");

            this.helpProvider1.SetShowHelp(this.fullyRandomRadioBtn, true);
            this.helpProvider1.SetHelpString(this.fullyRandomRadioBtn, "When randomizing guard patrols, do not prevent guards from sharing routes or nodes.");

            this.helpProvider1.SetShowHelp(this.noNodeSharingRadioBtn, true);
            this.helpProvider1.SetHelpString(this.noNodeSharingRadioBtn, "When randomizing guard patrols, prevent guards from sharing nodes on the same route.");

            this.helpProvider1.SetShowHelp(this.noRouteSharingRadioBtn, true);
            this.helpProvider1.SetHelpString(this.noRouteSharingRadioBtn, "When randomizing guard patrols, prevent guards from ever sharing the same route.");

            this.helpProvider1.SetShowHelp(this.randomizeReinforcementGuardTypesCheckBox, true);
            this.helpProvider1.SetHelpString(this.randomizeReinforcementGuardTypesCheckBox, "Randomize what types of guards are spawned when reinforcements are called for. Can be normal, shield, shield with light, shotgun, or hi-tech guards on both chapters.");

            this.helpProvider1.SetShowHelp(this.restoreBaseGameButton, true);
            this.helpProvider1.SetHelpString(this.restoreBaseGameButton, "Restores the game's files to their 'vanilla' state. If this does not work properly, use Steam to 'Verify integrity of game files' to accomplish the same result.");
        }

        private void LoadConfig()
        {
            try
            {
                _logger.Information($"Loading config from {_configLocation}...");
                string configContents = File.ReadAllText(_configLocation);
                Config config = JsonSerializer.Deserialize<Config>(configContents);

                InstallLocation = config.Mgs2ExePath;
                DirectoryInfo fileInfo = new DirectoryInfo(config.Mgs2ExePath);
                InstallLocation = fileInfo.FullName;
                randomizeSpawnsCheckbox.Checked = config.LastOptionsSelected.RandomizeSpawns;
                seedAlwaysBeatableCheckbox.Checked = config.LastOptionsSelected.NoHardLogicLocks;
                restrictNikitaCheckbox.Checked = config.LastOptionsSelected.NikitaShell2;
                allWeaponsWillSpawnCheckbox.Checked = config.LastOptionsSelected.AllWeaponsSpawnable;
                randomizeRationsCheckbox.Checked = config.LastOptionsSelected.IncludeRations;
                randomizeStartingItemsCheckbox.Checked = config.LastOptionsSelected.RandomizeStartingItems;
                randomizeAutomaticRewardsCheckbox.Checked = config.LastOptionsSelected.RandomizeAutomaticRewards;
                randomizeBombLocations.Checked = config.LastOptionsSelected.RandomizeC4;
                randomizeEFConnectingBridgeClaymores.Checked = config.LastOptionsSelected.RandomizeClaymores;
                randomizeTankerControlUnitLocations.Checked = config.LastOptionsSelected.RandomizeTankerControlUnits;
                addCardsCheckbox.Checked = config.LastOptionsSelected.RandomizeCards;
                restrictCard4CheckBox.Checked = config.LastOptionsSelected.Card4Shell2;
                keepVanillaCardLevelsCheckbox.Checked = config.LastOptionsSelected.KeepVanillaCardAccess;
                randomizeGuardValuesCheckBox.Checked = config.LastOptionsSelected.RandomizeGuardValues;
                insanityScalarTrackBar.Value = (int) (config.LastOptionsSelected.GuardRandomizationBounds * 100);
                if(insanityScalarTrackBar.Value < 20)
                {
                    insanityScalarTrackBar.Value = 20; //by default, do not allow less than 20 to avoid issues from unaware users.
                }
                keepGuardValuesConsistentAcrossLevelsCheckbox.Checked = config.LastOptionsSelected.KeepGuardValuesConsistentAcrossLevels;
                randomizeReinforcementGuardTypesCheckBox.Checked = config.LastOptionsSelected.RandomizeReinforcementGuardTypes;
                randomizeGuardPatrolsCheckbox.Checked = config.LastOptionsSelected.RandomizeGuardPatrols;
                switch (config.LastOptionsSelected.GuardPatrolRandomizationBehavior)
                {
                    case RandomizationOptions.RouteRandomizationBehavior.Full:
                        fullyRandomRadioBtn.Checked = true;
                        break;
                    case RandomizationOptions.RouteRandomizationBehavior.NoRouteShare:
                        noRouteSharingRadioBtn.Checked = true;
                        break;
                    case RandomizationOptions.RouteRandomizationBehavior.NoNodeShare:
                        noNodeSharingRadioBtn.Checked = true;
                        break;
                }

                if (!randomizeAutomaticRewardsCheckbox.Checked)
                {
                    addCardsCheckbox.Checked = false;
                    addCardsCheckbox.Enabled = false;
                }
                if(!addCardsCheckbox.Checked)
                {
                    restrictCard4CheckBox.Checked = false;
                    restrictCard4CheckBox.Enabled = false;
                    keepVanillaCardLevelsCheckbox.Checked = false;
                    keepVanillaCardLevelsCheckbox.Enabled = false;
                }
                if (!randomizeGuardValuesCheckBox.Checked)
                {
                    keepGuardValuesConsistentAcrossLevelsCheckbox.Checked = false;
                    keepGuardValuesConsistentAcrossLevelsCheckbox.Enabled = false;
                }
                _logger.Information($"Config loaded successfully!");
            }
            catch(Exception e)
            {
                _logger.Error($"Failed to load config: {e}");
            }
        }

        private void UpdateConfig()
        {
            try
            {
                _logger.Verbose("Updating config...");
                if (!_loaded)
                {
                    return;
                }
                Config config = new Config
                {
                    Mgs2ExePath = InstallLocation,
                    LastOptionsSelected = new RandomizationOptions
                    {
                        RandomizeSpawns = randomizeSpawnsCheckbox.Checked,
                        NoHardLogicLocks = seedAlwaysBeatableCheckbox.Checked,
                        NikitaShell2 = restrictNikitaCheckbox.Checked,
                        AllWeaponsSpawnable = allWeaponsWillSpawnCheckbox.Checked,
                        IncludeRations = randomizeRationsCheckbox.Checked,
                        RandomizeStartingItems = randomizeStartingItemsCheckbox.Checked,
                        RandomizeAutomaticRewards = randomizeAutomaticRewardsCheckbox.Checked,
                        RandomizeC4 = randomizeBombLocations.Checked,
                        RandomizeClaymores = randomizeEFConnectingBridgeClaymores.Checked,
                        RandomizeCards = addCardsCheckbox.Checked,
                        Card4Shell2 = restrictCard4CheckBox.Checked,
                        KeepVanillaCardAccess = keepVanillaCardLevelsCheckbox.Checked,
                        RandomizeTankerControlUnits = randomizeTankerControlUnitLocations.Checked,
                        RandomizeGuardValues = randomizeGuardValuesCheckBox.Checked,
                        GuardRandomizationBounds = insanityScalarTrackBar.Value / 100f,
                        KeepGuardValuesConsistentAcrossLevels = keepGuardValuesConsistentAcrossLevelsCheckbox.Checked,
                        RandomizeReinforcementGuardTypes = randomizeReinforcementGuardTypesCheckBox.Checked,
                        RandomizeGuardPatrols = randomizeGuardPatrolsCheckbox.Checked,
                        GuardPatrolRandomizationBehavior = fullyRandomRadioBtn.Checked ? RandomizationOptions.RouteRandomizationBehavior.Full : 
                            noNodeSharingRadioBtn.Checked ? RandomizationOptions.RouteRandomizationBehavior.NoNodeShare : 
                            RandomizationOptions.RouteRandomizationBehavior.NoRouteShare
                    }
                };

                string configContents = JsonSerializer.Serialize(config);
                File.WriteAllText(_configLocation, configContents);
            }
            catch(Exception e)
            {
                _logger.Error($"Failed to update config: {e}");
            }
        }

        private void ToggleControls(bool enable)
        {
            try
            {
                _logger.Information($"Toggling controls to state: {enable}");
                browseButton.Enabled = enable;
                randomizeButton.Enabled = enable;
                restoreBaseGameButton.Enabled = enable;
                randomizeSpawnsCheckbox.Enabled = enable;
                if (randomizeSpawnsCheckbox.Checked)
                {
                    seedAlwaysBeatableCheckbox.Enabled = enable;
                    restrictNikitaCheckbox.Enabled = enable;
                    allWeaponsWillSpawnCheckbox.Enabled = enable;
                    randomizeRationsCheckbox.Enabled = enable;
                    randomizeStartingItemsCheckbox.Enabled = enable;
                    randomizeAutomaticRewardsCheckbox.Enabled = enable;
                }
                randomizeBombLocations.Enabled = enable;
                randomizeEFConnectingBridgeClaymores.Enabled = enable;
                randomizeTankerControlUnitLocations.Enabled = enable;
                randomizeGuardValuesCheckBox.Enabled = enable;
                randomizeReinforcementGuardTypesCheckBox.Enabled = enable;
                randomizeGuardPatrolsCheckbox.Enabled = enable;
                if (randomizeGuardValuesCheckBox.Checked)
                {
                    insanityScalarLabel.Enabled = enable;
                    insanityScalarTrackBar.Enabled = enable;
                    keepGuardValuesConsistentAcrossLevelsCheckbox.Enabled = enable;
                }
                if (randomizeGuardPatrolsCheckbox.Checked)
                {
                    fullyRandomRadioBtn.Enabled = enable;
                    noNodeSharingRadioBtn.Enabled = enable;
                    noRouteSharingRadioBtn.Enabled = enable;
                }
                if (randomizeAutomaticRewardsCheckbox.Checked && randomizeAutomaticRewardsCheckbox.Enabled)
                {
                    addCardsCheckbox.Enabled = enable;
                }
                if (addCardsCheckbox.Checked && addCardsCheckbox.Enabled)
                {
                    keepVanillaCardLevelsCheckbox.Enabled = enable;
                }
                if (customSeedCheckbox.Checked)
                {
                    seedUpDown.Enabled = enable;
                }
                else
                    seedUpDown.Value = 0;
                customSeedCheckbox.Enabled = enable;
                _logger.Information("Controls toggled successfully");
            }
            catch(Exception e)
            {
                _logger.Error($"Controls failed to toggle as expected: {e}");
            }
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            try
            {
                string executableLocation = InstallLocation;

                if (string.IsNullOrWhiteSpace(executableLocation) || !Directory.Exists(executableLocation))
                {
                    executableLocation = Environment.CurrentDirectory;
                }

                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    Multiselect = false,
                    Title = "Where is 'METAL GEAR SOLID2.exe' on your machine?",
                    DefaultExt = ".exe",
                    InitialDirectory = executableLocation
                };
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    _logger.Verbose($"Updated MGS2 Executable location to: {openFileDialog.FileName}");
                    FileInfo selectedFileInfo = new FileInfo(openFileDialog.FileName);
                    InstallLocation = selectedFileInfo.DirectoryName;
                    UpdateConfig();
                }
            }
            catch(Exception ex)
            {
                _logger.Error($"Failed to update MGS2 Executable location: {ex}");
                MessageBox.Show("Failed to update MGS2 executable location! If this persists, please report a bug and attach the `MGS2Randomizer.log` file from your documents to it!");
            }
        }

        private void seedAlwaysBeatableCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            UpdateConfig();
        }

        private void restrictNikitaCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (!restrictNikitaCheckbox.Checked && _loaded)
            {
                MessageBox.Show("This can cause logic-locks if the Nikita spawns on Shell 1 and you do not pick it up before fighting the Harrier.", "WARNING");
            }
            UpdateConfig();
        }

        private void allWeaponsWillSpawnCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            UpdateConfig();
        }

        private void randomizeRationsCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            UpdateConfig();
        }

        private void randomizeStartingItemsCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            UpdateConfig();
        }

        private void randomizeAutomaticRewardsCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            addCardsCheckbox.Enabled = randomizeAutomaticRewardsCheckbox.Checked && randomizeAutomaticRewardsCheckbox.Enabled;
            UpdateConfig();
        }

        private void randomizeBombLocations_CheckedChanged(object sender, EventArgs e)
        {
            UpdateConfig();
        }

        private void randomizeEFConnectingBridgeClaymores_CheckedChanged(object sender, EventArgs e)
        {
            UpdateConfig();
        }

        private void randomizeSpawnsCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            seedAlwaysBeatableCheckbox.Enabled = randomizeSpawnsCheckbox.Checked;
            restrictNikitaCheckbox.Enabled = randomizeSpawnsCheckbox.Checked;
            allWeaponsWillSpawnCheckbox.Enabled = randomizeSpawnsCheckbox.Checked;
            randomizeRationsCheckbox.Enabled = randomizeSpawnsCheckbox.Checked;
            randomizeStartingItemsCheckbox.Enabled = randomizeSpawnsCheckbox.Checked;
            randomizeAutomaticRewardsCheckbox.Enabled = randomizeSpawnsCheckbox.Checked;
            UpdateConfig();
        }

        private void addCardsCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            keepVanillaCardLevelsCheckbox.Enabled = addCardsCheckbox.Checked && addCardsCheckbox.Enabled;
            restrictCard4CheckBox.Enabled = addCardsCheckbox.Checked && addCardsCheckbox.Enabled;
            UpdateConfig();
        }

        private void keepVanillaCardLevelsCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            UpdateConfig();
        }

        private void randomizeTankerControlUnitLocations_CheckedChanged(object sender, EventArgs e)
        {
            UpdateConfig();
        }

        private void customSeedCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (customSeedCheckbox.Checked)
                MessageBox.Show("Heads up: be sure to check your settings to get accurate seed results. If you have different settings than the seed's original settings, you will get different output.");
            seedUpDown.Enabled = customSeedCheckbox.Checked;
        }

        private void restoreBaseGameButton_Click(object sender, EventArgs e)
        {
            try
            {
                _logger.Information("Restoring base game files");
                MessageBox.Show("Restoring MGS2's base game files, this will take but a moment...");
                ToggleControls(false);
                MGS2Randomizer randomizer = new MGS2Randomizer(InstallLocation);
                randomizer.Derandomize();
                ToggleControls(true);
                MessageBox.Show("MGS2's base game files are restored! Enjoy vanilla MGS2!");
                _logger.Information("Base game files restored");
            }
            catch(Exception ex)
            {
                _logger.Error($"Something went wrong when trying to restore base game files: {ex}");
            }
        }

        private async void randomizeButton_Click(object sender, EventArgs e)
        {
            try
            {
                if(randomizeGuardValuesCheckBox.Checked && insanityScalarTrackBar.Value < 20)
                {
                    DialogResult response = MessageBox.Show("Your randomization bounds for guard values is set to less than the recommended 20%, this may cause severe gameplay issues!\r\n\r\n" +
                        "Are you sure you want to continue with these settings?", "WARNING", MessageBoxButtons.YesNo);
                    if (response == DialogResult.No)
                    {
                        return;
                    }
                }
                UpdateConfig();
                _logger.Information("Randomizing game files...");
                MessageBox.Show("Randomizing MGS2's game files to your specifications, this may take some time...", "Heads up!");
                ToggleControls(false);
                Application.DoEvents();
                waitingMusic.PlayLooping();
                float insanityScalarValue = insanityScalarTrackBar.Value;
                await Task.Run(() =>
                {
                    MGS2Randomizer randomizer = new MGS2Randomizer(InstallLocation, (int)seedUpDown.Value);
                    RandomizationOptions randomizationOptions = new RandomizationOptions
                    {
                        RandomizeSpawns = randomizeSpawnsCheckbox.Checked,
                        NoHardLogicLocks = seedAlwaysBeatableCheckbox.Checked,
                        NikitaShell2 = restrictNikitaCheckbox.Checked,
                        AllWeaponsSpawnable = allWeaponsWillSpawnCheckbox.Checked,
                        IncludeRations = randomizeRationsCheckbox.Checked,
                        RandomizeStartingItems = randomizeStartingItemsCheckbox.Checked,
                        RandomizeAutomaticRewards = randomizeAutomaticRewardsCheckbox.Checked,
                        RandomizeC4 = randomizeBombLocations.Checked,
                        RandomizeClaymores = randomizeEFConnectingBridgeClaymores.Checked,
                        RandomizeCards = addCardsCheckbox.Checked,
                        Card4Shell2 = restrictCard4CheckBox.Checked,
                        KeepVanillaCardAccess = keepVanillaCardLevelsCheckbox.Checked,
                        RandomizeTankerControlUnits = randomizeTankerControlUnitLocations.Checked,
                        RandomizeGuardValues = randomizeGuardValuesCheckBox.Checked,
                        GuardRandomizationBounds = insanityScalarValue / 100,
                        KeepGuardValuesConsistentAcrossLevels = keepGuardValuesConsistentAcrossLevelsCheckbox.Checked,
                        RandomizeReinforcementGuardTypes = randomizeReinforcementGuardTypesCheckBox.Checked,
                        RandomizeGuardPatrols = randomizeGuardPatrolsCheckbox.Checked,
                        GuardPatrolRandomizationBehavior = GetRouteRandomizationBehavior()
                    };
                    _logger.Debug($"Calling randomize item spawns with randomization options: {randomizationOptions}");
                    int seed = 0;
                    if (randomizer.Seed == 0)
                        randomizer.Randomizer = new Random(DateTime.UtcNow.Hour + DateTime.UtcNow.Minute + DateTime.UtcNow.Second + DateTime.UtcNow.Millisecond);
                    while (seed == 0)
                    {
                        try
                        {
                            seed = randomizer.RandomizeMGS2(randomizationOptions);
                            _logger.Debug("Items randomized successfully, now saving to disk");
                            randomizer.SaveRandomizationToDisk(true, false);
                            _logger.Debug("Randomization saved to disk successfully!");
                        }
                        catch (OutOfMemoryException oome)
                        {
                            throw oome; //rethrow to help debug
                        }
                        catch (RandomizerException ee)
                        {
                            _logger.Debug("Bad seed, trying to randomize again");
                            //randomizer.Seed = new Random(DateTime.UtcNow.Hour + DateTime.UtcNow.Minute + DateTime.UtcNow.Second + DateTime.UtcNow.Millisecond);
                            //randomizer.Randomizer = new Random(DateTime.UtcNow.Hour + DateTime.UtcNow.Minute + DateTime.UtcNow.Second + DateTime.UtcNow.Millisecond);
                            randomizer.Seed = randomizer.Randomizer.Next();
                            randomizer.Randomizer = new Random(randomizer.Seed);
                        }
                        catch (Exception ee)
                        {
                            throw ee; //rethrow to help debug
                        }
                    }
                });
                waitingMusic.Stop();
                keptYouWaitingHuh.Play();
                MessageBox.Show("Finished! Spoiler file available in your Documents folder.", "Randomization Complete!");
                ToggleControls(true);
            }
            catch(Exception ex)
            {
                _logger.Error($"Randomization failed: {ex}");
                MessageBox.Show("Randomization failed! If this error persists, please report a bug on Github!");
            }
            finally
            {

            }
        }

        private RandomizationOptions.RouteRandomizationBehavior GetRouteRandomizationBehavior()
        {
            if (fullyRandomRadioBtn.Checked)
                return RandomizationOptions.RouteRandomizationBehavior.Full;
            else if (noNodeSharingRadioBtn.Checked)
                return RandomizationOptions.RouteRandomizationBehavior.NoNodeShare;
            else
                return RandomizationOptions.RouteRandomizationBehavior.NoRouteShare;
        }

        private void ReportABug_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("https://github.com/sagefantasma/mgs2mc-randomizer/issues");
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Failed to launch Github page. If this error persists, please restart the application.");
            }
        }

        private void KofiButton_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("If you're enjoying the randomizer, please consider donating to my Ko-Fi to support me and the project!",
                    "Support the project on Ko-Fi!", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Process.Start("https://ko-fi.com/sagefantasma");
                }
            }
            catch(Exception ex)
            {

            }
        }

        private void randomizeGuardValuesCheckBox_CheckChanged(object sender, EventArgs e)
        {
            keepGuardValuesConsistentAcrossLevelsCheckbox.Enabled = randomizeGuardValuesCheckBox.Checked;
            insanityScalarLabel.Enabled = randomizeGuardValuesCheckBox.Checked;
            insanityScalarTrackBar.Enabled = randomizeGuardValuesCheckBox.Checked;
            UpdateConfig();
        }

        private void keepGuardValuesConsistentAcrossLevelsCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            UpdateConfig();
        }

        private void randomizeAutomaticRewardsCheckbox_EnabledChanged(object sender, EventArgs e)
        {
            if (!randomizeAutomaticRewardsCheckbox.Enabled)
            {
                addCardsCheckbox.Enabled = false;
            }
            else
            {
                if (randomizeAutomaticRewardsCheckbox.Checked)
                {
                    addCardsCheckbox.Enabled = true;
                }
            }
        }

        private void addCardsCheckbox_EnabledChanged(object sender, EventArgs e)
        {
            if (!addCardsCheckbox.Enabled)
            {
                restrictCard4CheckBox.Enabled = false;
                keepVanillaCardLevelsCheckbox.Enabled = false;
            }
            else
            {
                if (addCardsCheckbox.Checked)
                {
                    restrictCard4CheckBox.Enabled = true;
                    keepVanillaCardLevelsCheckbox.Enabled = true;
                }
            }
        }

        private void changelogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowChangelog();
        }

        private void randomizeReinforcementGuardTypesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            UpdateConfig();
        }

        private void randomizeGuardPatrolsCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            UpdateConfig();
            fullyRandomRadioBtn.Enabled = randomizeGuardPatrolsCheckbox.Checked;
            noNodeSharingRadioBtn.Enabled = randomizeGuardPatrolsCheckbox.Checked;
            noRouteSharingRadioBtn.Enabled = randomizeGuardPatrolsCheckbox.Checked;
        }

        private void restrictCard4CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            UpdateConfig();
        }
    }
}
