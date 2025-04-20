using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MGS2_Randomizer
{
    public partial class RandomizationForm : Form
    {
        private string _installLocation { get; set; }
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

        public RandomizationForm()
        {
            InitializeComponent();
            LoadConfig();
            SetupHelperButton();
            _loaded = true;
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

            this.helpProvider1.SetShowHelp(this.keepVanillaCardLevelsCheckbox, true);
            this.helpProvider1.SetHelpString(this.keepVanillaCardLevelsCheckbox, "If cards are in the randomization pool, you can enable this option to keep items at their 'native' spawn level. (AKS-74u will be behind a Lv2 door, PSG-1 will be behind a Lv3 door, etc...)");

            this.helpProvider1.SetShowHelp(this.randomizeBombLocations, true);
            this.helpProvider1.SetHelpString(this.randomizeBombLocations, "Randomize where all bombs during the bomb defusal segment spawn.");

            this.helpProvider1.SetShowHelp(this.randomizeEFConnectingBridgeClaymores, true);
            this.helpProvider1.SetHelpString(this.randomizeEFConnectingBridgeClaymores, "Randomize where the claymores spawn on the EF Connecting Bridge.");

            this.helpProvider1.SetShowHelp(this.randomizeTankerControlUnitLocations, true);
            this.helpProvider1.SetHelpString(this.randomizeTankerControlUnitLocations, "Randomize where control units spawn in the engine room on the Tanker.");

            this.helpProvider1.SetShowHelp(this.restoreBaseGameButton, true);
            this.helpProvider1.SetHelpString(this.restoreBaseGameButton, "Restores the game's files to their 'vanilla' state. If this does not work properly, use Steam to 'Verify integrity of game files' to accomplish the same result.");
        }

        private void LoadConfig()
        {
            string configContents = File.ReadAllText(_configLocation);
            Config config = JsonSerializer.Deserialize<Config>(configContents);

            mgs2ExeTextBox.Text = config.Mgs2ExePath;
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
            keepVanillaCardLevelsCheckbox.Checked = config.LastOptionsSelected.KeepVanillaCardAccess;
        }

        private void UpdateConfig()
        {
            if (!_loaded)
            {
                return;
            }
            Config config = new Config
            {
                Mgs2ExePath = mgs2ExeTextBox.Text,
                LastOptionsSelected = new MGS2Randomizer.RandomizationOptions
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
                    KeepVanillaCardAccess = keepVanillaCardLevelsCheckbox.Checked,
                    RandomizeTankerControlUnits = randomizeTankerControlUnitLocations.Checked
                }
            };

            string configContents = JsonSerializer.Serialize(config);
            File.WriteAllText(_configLocation, configContents);
        }

        private void ToggleControls(bool enable)
        {
            browseButton.Enabled = enable;
            randomizeButton.Enabled = enable;
            restoreBaseGameButton.Enabled = enable;
            randomizeSpawnsCheckbox.Enabled = enable;
            seedAlwaysBeatableCheckbox.Enabled = enable;
            restrictNikitaCheckbox.Enabled = enable;
            allWeaponsWillSpawnCheckbox.Enabled = enable;
            randomizeRationsCheckbox.Enabled = enable;
            randomizeStartingItemsCheckbox.Enabled = enable;
            randomizeAutomaticRewardsCheckbox.Enabled = enable;
            randomizeBombLocations.Enabled = enable;
            randomizeEFConnectingBridgeClaymores.Enabled = enable;
            randomizeTankerControlUnitLocations.Enabled = enable;
            if (!enable && randomizeAutomaticRewardsCheckbox.Checked)
            {
                addCardsCheckbox.Enabled = enable;
            }
            if (!enable && addCardsCheckbox.Checked)
            {
                keepVanillaCardLevelsCheckbox.Enabled = enable;
            }
            if (!enable && customSeedCheckbox.Checked)
            {
                seedUpDown.Enabled = enable;
            }
            else
                seedUpDown.Value = 0;
            customSeedCheckbox.Enabled = enable;
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            string executableLocation = mgs2ExeTextBox.Text;

            if (string.IsNullOrWhiteSpace(executableLocation) || !File.Exists(executableLocation))
            {
                executableLocation = Environment.CurrentDirectory;
            }

            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Multiselect = false,
                Title = "Where is 'METAL GEAR SOLID2.exe' on your machine?",
                DefaultExt = ".exe",
                InitialDirectory = Path.GetDirectoryName(executableLocation)
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                mgs2ExeTextBox.Text = openFileDialog.FileName;
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
            addCardsCheckbox.Enabled = randomizeAutomaticRewardsCheckbox.Checked;
            if (!randomizeAutomaticRewardsCheckbox.Checked)
            {
                addCardsCheckbox.Checked = false;
            }
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
            addCardsCheckbox.Enabled = randomizeSpawnsCheckbox.Checked;
            keepVanillaCardLevelsCheckbox.Enabled = randomizeSpawnsCheckbox.Checked;
            UpdateConfig();
        }

        private void addCardsCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            keepVanillaCardLevelsCheckbox.Enabled = addCardsCheckbox.Checked;
            if (!addCardsCheckbox.Checked)
            {
                keepVanillaCardLevelsCheckbox.Checked = false;
            }
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
            MessageBox.Show("Restoring MGS2's base game files, this will take but a moment...");
            ToggleControls(false);
            MGS2Randomizer randomizer = new MGS2Randomizer(InstallLocation);
            randomizer.Derandomize();
            ToggleControls(true);
            MessageBox.Show("MGS2's base game files are restored! Enjoy vanilla MGS2!");
        }

        private async void randomizeButton_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("Randomizing MGS2's game files to your specifications, this may take some time...", "Heads up!");
                ToggleControls(false);
                Application.DoEvents();
                waitingMusic.PlayLooping();
                await Task.Run(() =>
                {
                    MGS2Randomizer randomizer = new MGS2Randomizer(InstallLocation, (int)seedUpDown.Value);
                    MGS2Randomizer.RandomizationOptions randomizationOptions = new MGS2Randomizer.RandomizationOptions
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
                        KeepVanillaCardAccess = keepVanillaCardLevelsCheckbox.Checked,
                        RandomizeTankerControlUnits = randomizeTankerControlUnitLocations.Checked
                    };
                    int seed = 0;
                    if (randomizer.Seed == 0)
                        randomizer.Randomizer = new Random(DateTime.UtcNow.Hour + DateTime.UtcNow.Minute + DateTime.UtcNow.Second + DateTime.UtcNow.Millisecond);
                    while (seed == 0)
                    {
                        try
                        {
                            seed = randomizer.RandomizeItemSpawns(randomizationOptions);
                            randomizer.SaveRandomizationToDisk(true, false);
                        }
                        catch (OutOfMemoryException oome)
                        {
                            throw oome; //rethrow to help debug
                        }
                        catch (MGS2Randomizer.RandomizerException ee)
                        {
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
                MessageBox.Show("Randomization failed! If this error persists, please report a bug on Github!");
            }
            finally
            {

            }
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
    }
}
