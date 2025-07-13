using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MGS2_Randomizer
{
    internal static class ResourceEditor
    {
        static List<byte> _manifestContents { get; set; }
        static List<byte> _bpAssetsContents { get; set; }

        static byte[] EOL = new byte[] { 0x0D, 0x0D, 0x0A };

        private class MGS2ResourceData
        {
            public string Name { get; set; }
            public string Text { get; set; }
            public FileType FileType { get; set; }
            public BasicResource Resource { get; set; }
        }

        private class LevelResources
        {
            public void ReplaceAnyIdCollision(MGS2ResourceData resourceToCheck)
            {
                int indexToReplace;
                switch (resourceToCheck.FileType)
                {
                    case FileType.Kms:
                        indexToReplace = Manifest.KmsFiles.FindIndex(resource => resource.Contains($"/{resourceToCheck.Resource.Id}."));
                        if (indexToReplace > 0)
                            Manifest.KmsFiles.RemoveAt(indexToReplace);
                        break;
                    case FileType.Ctxr:
                        indexToReplace = BpAssets.CtxrFiles.FindIndex(resource => resource.Contains($"/{resourceToCheck.Resource.Id}."));
                        if (indexToReplace > 0)
                            BpAssets.CtxrFiles.RemoveAt(indexToReplace);
                        break;
                    case FileType.Cmdl:
                        //TODO: this WILL cause problems in the future if evm resources are ever part of this.
                        indexToReplace = BpAssets.KmsFiles.FindIndex(resource => resource.Contains($"/{resourceToCheck.Resource.Id}."));
                        if (indexToReplace > 0)
                            BpAssets.KmsFiles.RemoveAt(indexToReplace);
                        break;
                    case FileType.Tri:
                        indexToReplace = Manifest.TriFiles.FindIndex(resource => resource.Contains($"/{resourceToCheck.Resource.Id}."));
                        if (indexToReplace > 0)
                            Manifest.TriFiles.RemoveAt(indexToReplace);
                        break;
                    case FileType.Sar:
                        indexToReplace = Manifest.SarFiles.FindIndex(resource => resource.Contains($"/{resourceToCheck.Resource.Id}."));
                        if (indexToReplace > 0)
                            Manifest.SarFiles.RemoveAt(indexToReplace);
                        break;
                    case FileType.Mar:
                        indexToReplace = Manifest.MarFiles.FindIndex(resource => resource.Contains($"/{resourceToCheck.Resource.Id}."));
                        if (indexToReplace > 0)
                            Manifest.MarFiles.RemoveAt(indexToReplace);
                        break;
                    case FileType.Cv2:
                        indexToReplace = Manifest.Cv2Files.FindIndex(resource => resource.Contains($"/{resourceToCheck.Resource.Id}."));
                        if (indexToReplace > 0)
                            Manifest.Cv2Files.RemoveAt(indexToReplace);
                        break;
                }
            }

            public bool CheckForDuplicates(MGS2ResourceData resource)
            {
                switch (resource.FileType)
                {
                    case FileType.Kms:
                        if (Manifest.KmsFiles.Any(kms => kms.Contains(resource.Resource.Name)))
                            return false;
                        break;
                    case FileType.Ctxr:
                        if (BpAssets.CtxrFiles.Any(ctxr => ctxr.Contains(resource.Text)))
                            return false;
                        break;
                    case FileType.Cmdl:
                        if (BpAssets.KmsFiles.Any(cmdl => cmdl.Contains(resource.Resource.Name)))
                            return false;
                        break;
                    case FileType.Tri:
                        if (Manifest.TriFiles.Any(tri => tri.Contains(resource.Text)))
                            return false;
                        break;
                    case FileType.Sar:
                        if (Manifest.SarFiles.Any(sar => sar.Contains(resource.Resource.Name)))
                            return false;
                        break;
                    case FileType.Mar:
                        if (Manifest.MarFiles.Any(mar => mar.Contains(resource.Resource.Name)))
                            return false;
                        break;
                    case FileType.Cv2:
                        if (Manifest.Cv2Files.Any(mar => mar.Contains(resource.Resource.Name)))
                            return false;
                        break;
                }

                return true;
            }

            public BpAssets BpAssets { get; set; } = new BpAssets();
            public Manifest Manifest { get; set; } = new Manifest();
        }

        private class BpAssets
        {
            public List<string> CtxrFiles { get; set; } = new List<string>();
            public List<string> EvmFiles { get; set; } = new List<string>(); //can be null
            public List<string> KmsFiles { get; set; } = new List<string>();

            /*
         * bp_assets file order:
         * 
         * alphabetically stored ctxr files
         * alphabetically stored evm files
         * alphabetically stored kms files
         */
            public byte[] ToBytes()
            {
                List<byte> bytes = new List<byte>();
                CtxrFiles.Sort();
                KmsFiles.Sort();
                foreach (string resource in this.CtxrFiles)
                {
                    bytes.AddRange(Encoding.UTF8.GetBytes(resource));
                    //bytes.AddRange(EOL);
                }
                foreach (string resource in this.EvmFiles)
                {
                    bytes.AddRange(Encoding.UTF8.GetBytes(resource));
                    //bytes.AddRange(EOL);
                }
                foreach (string resource in this.KmsFiles)
                {
                    bytes.AddRange(Encoding.UTF8.GetBytes(resource));
                    //bytes.AddRange(EOL);
                }

                return bytes.ToArray();
            }
        }

        private class Manifest
        {
            public List<string> TriFiles { get; set; } = new List<string>();
            public List<string> HzxFiles { get; set; } = new List<string>();
            public List<string> VarFiles { get; set; } = new List<string>();
            public List<string> SarFiles { get; set; } = new List<string>();
            public List<string> RowFiles { get; set; } = new List<string>();
            public List<string> O2dFiles { get; set; } = new List<string>();
            public List<string> MarFiles { get; set; } = new List<string>();
            public List<string> Lt2Files { get; set; } = new List<string>();
            public List<string> KmsFiles { get; set; } = new List<string>();
            public List<string> FarFiles { get; set; } = new List<string>();
            public List<string> EvmFiles { get; set; } = new List<string>(); //can be null
            public List<string> Cv2Files { get; set; } = new List<string>();
            public List<string> AnmFiles { get; set; } = new List<string>();
            public List<string> GcxFiles { get; set; } = new List<string>();


            /*
         * manifest file order:
         * alphabetically stored tri files
         * alphabetically stored? hzx files
         * var files
         * sar files
         * reverse-alphabetically stored? row files
         * mar files
         * lt2 files
         * reverse-alphabetically stored kms files
         * reverse-alphabetically stored cv2 files
         * gcx file
         */
            public byte[] ToBytes()
            {
                List<byte> bytes = new List<byte>();
                TriFiles.Sort();
                KmsFiles.Sort();
                KmsFiles.Reverse();

                foreach (string resource in this.TriFiles)
                {
                    bytes.AddRange(Encoding.UTF8.GetBytes(resource));
                    //bytes.AddRange(EOL);
                }
                foreach (string resource in this.HzxFiles)
                {
                    bytes.AddRange(Encoding.UTF8.GetBytes(resource));
                    //bytes.AddRange(EOL);
                }
                foreach (string resource in this.VarFiles)
                {
                    bytes.AddRange(Encoding.UTF8.GetBytes(resource));
                    //bytes.AddRange(EOL);
                }
                foreach (string resource in this.SarFiles)
                {
                    bytes.AddRange(Encoding.UTF8.GetBytes(resource));
                    //bytes.AddRange(EOL);
                }
                foreach (string resource in this.RowFiles)
                {
                    bytes.AddRange(Encoding.UTF8.GetBytes(resource));
                    //bytes.AddRange(EOL);
                }
                foreach (string resource in this.O2dFiles)
                {
                    bytes.AddRange(Encoding.UTF8.GetBytes(resource));
                    //bytes.AddRange(EOL);
                }
                foreach (string resource in this.MarFiles)
                {
                    bytes.AddRange(Encoding.UTF8.GetBytes(resource));
                    //bytes.AddRange(EOL);
                }
                foreach (string resource in this.Lt2Files)
                {
                    bytes.AddRange(Encoding.UTF8.GetBytes(resource));
                    //bytes.AddRange(EOL);
                }
                foreach (string resource in this.KmsFiles)
                {
                    bytes.AddRange(Encoding.UTF8.GetBytes(resource));
                    //bytes.AddRange(EOL);
                }
                foreach (string resource in this.FarFiles)
                {
                    bytes.AddRange(Encoding.UTF8.GetBytes(resource));
                    //bytes.AddRange(EOL);
                }
                foreach (string resource in this.EvmFiles)
                {
                    bytes.AddRange(Encoding.UTF8.GetBytes(resource));
                    //bytes.AddRange(EOL);
                }
                foreach (string resource in this.Cv2Files)
                {
                    bytes.AddRange(Encoding.UTF8.GetBytes(resource));
                    //bytes.AddRange(EOL);
                }
                foreach (string resource in this.AnmFiles)
                {
                    bytes.AddRange(Encoding.UTF8.GetBytes(resource));
                    //bytes.AddRange(EOL);
                }
                foreach (string resource in this.GcxFiles)
                {
                    bytes.AddRange(Encoding.UTF8.GetBytes(resource));
                    //bytes.AddRange(EOL);
                }

                return bytes.ToArray();
            }
        }

        enum FileType
        {
            Kms,
            Cmdl,
            Ctxr,
            Tri,
            Sar,
            Mar,
            Cv2
        }

        private static LevelResources CollectExistingResources()
        {
            LevelResources existingResources = new LevelResources();
            List<byte[]> individualizedBpAssets = SplitResources(_bpAssetsContents.ToArray());
            List<byte[]> individualizedManifest = SplitResources(_manifestContents.ToArray());

            foreach (byte[] resource in individualizedBpAssets)
            {
                string resourceString = Encoding.UTF8.GetString(resource);
                if (resourceString.StartsWith("textures/"))
                {
                    existingResources.BpAssets.CtxrFiles.Add(resourceString);
                }
                else if (resourceString.StartsWith("assets/evm/"))
                {
                    existingResources.BpAssets.EvmFiles.Add(resourceString);
                }
                else if (resourceString.StartsWith("assets/kms/"))
                {
                    existingResources.BpAssets.KmsFiles.Add(resourceString);
                }
                else if (resourceString != "")
                {
                    throw new NotImplementedException("Unexpected asset type!");
                }
            }

            foreach (byte[] resource in individualizedManifest)
            {
                string resourceString = Encoding.UTF8.GetString(resource);
                if (resourceString.StartsWith("assets/tri/"))
                {
                    existingResources.Manifest.TriFiles.Add(resourceString);
                }
                else if (resourceString.StartsWith("assets/hzx/"))
                {
                    existingResources.Manifest.HzxFiles.Add(resourceString);
                }
                else if (resourceString.StartsWith("assets/var/"))
                {
                    existingResources.Manifest.VarFiles.Add(resourceString);
                }
                else if (resourceString.StartsWith("assets/sar/"))
                {
                    existingResources.Manifest.SarFiles.Add(resourceString);
                }
                else if (resourceString.StartsWith("assets/row/"))
                {
                    existingResources.Manifest.RowFiles.Add(resourceString);
                }
                else if (resourceString.StartsWith("assets/o2d"))
                {
                    existingResources.Manifest.O2dFiles.Add(resourceString);
                }
                else if (resourceString.StartsWith("assets/mar/"))
                {
                    existingResources.Manifest.MarFiles.Add(resourceString);
                }
                else if (resourceString.StartsWith("assets/lt2/"))
                {
                    existingResources.Manifest.Lt2Files.Add(resourceString);
                }
                else if (resourceString.StartsWith("assets/kms/"))
                {
                    existingResources.Manifest.KmsFiles.Add(resourceString);
                }
                else if (resourceString.StartsWith("assets/far/"))
                {
                    existingResources.Manifest.FarFiles.Add(resourceString);
                }
                else if (resourceString.StartsWith("assets/evm/"))
                {
                    existingResources.Manifest.EvmFiles.Add(resourceString);
                }
                else if (resourceString.StartsWith("assets/cv2/"))
                {
                    existingResources.Manifest.Cv2Files.Add(resourceString);
                }
                else if (resourceString.StartsWith("assets/anm/"))
                {
                    existingResources.Manifest.AnmFiles.Add(resourceString);
                }
                else if (resourceString.StartsWith("assets/gcx/"))
                {
                    existingResources.Manifest.GcxFiles.Add(resourceString);
                }
                else if (resourceString != "")
                {
                    throw new NotImplementedException("Unexpected asset type!");
                }
            }

            return existingResources;
        }

        public static void AddResources(string gcxFile, string resourceSuperDirectory, List<string> resourcesToAdd)
        {
            try
            {
                DirectoryInfo resourceSuperDirectoryInfo = new DirectoryInfo(resourceSuperDirectory);
                DirectoryInfo gcxResourceDirectory = resourceSuperDirectoryInfo.GetDirectories(gcxFile).FirstOrDefault();
                FileInfo bpAssets = gcxResourceDirectory.GetFiles("bp_assets.txt").FirstOrDefault();
                FileInfo manifest = gcxResourceDirectory.GetFiles("manifest.txt").FirstOrDefault();
                _bpAssetsContents = File.ReadAllBytes(bpAssets.FullName).ToList();
                _manifestContents = File.ReadAllBytes(manifest.FullName).ToList();

                List<MGS2ResourceData> missingData = new List<MGS2ResourceData>();
                foreach (string resourceToAdd in resourcesToAdd)
                {
                    missingData.AddRange(PrepareListOfDataToAdd(resourceToAdd));
                }
                ReplaceStageNames(missingData, gcxFile);

                bool modifiedManifest = false;
                bool modifiedBpAssets = false;

                LevelResources levelResources = CollectExistingResources();

                foreach (MGS2ResourceData dataToAdd in missingData)
                {
                    if (!dataToAdd.Resource.ReplaceExistingId)
                    {
                        if (!levelResources.CheckForDuplicates(dataToAdd))
                        {
                            continue;
                        }
                    }
                    else
                    {
                        levelResources.ReplaceAnyIdCollision(dataToAdd);
                    }

                    switch (dataToAdd.FileType)
                    {
                        case FileType.Cmdl:
                            modifiedBpAssets = true;
                            levelResources.BpAssets.KmsFiles.Add(dataToAdd.Text);
                            break;
                        case FileType.Ctxr:
                            modifiedBpAssets = true;
                            levelResources.BpAssets.CtxrFiles.Add(dataToAdd.Text);
                            break;
                        case FileType.Kms:
                            modifiedManifest = true;
                            levelResources.Manifest.KmsFiles.Add(dataToAdd.Text);
                            break;
                        case FileType.Tri:
                            modifiedManifest = true;
                            levelResources.Manifest.TriFiles.Add(dataToAdd.Text);
                            break;
                        case FileType.Sar:
                            modifiedManifest = true;
                            levelResources.Manifest.SarFiles.Add(dataToAdd.Text);
                            break;
                        case FileType.Mar:
                            modifiedManifest = true;
                            levelResources.Manifest.MarFiles.Add(dataToAdd.Text);
                            break;
                        case FileType.Cv2:
                            modifiedManifest = true;
                            levelResources.Manifest.Cv2Files.Add(dataToAdd.Text);
                            break;
                    }
                }

                //Directory.CreateDirectory(gcxFile);
                if (modifiedBpAssets)
                    File.WriteAllBytes(bpAssets.FullName, levelResources.BpAssets.ToBytes());
                if (modifiedManifest)
                    File.WriteAllBytes(manifest.FullName, levelResources.Manifest.ToBytes());
            }
            catch (Exception ex)
            {

            }
        }

        private static List<byte[]> SplitResources(byte[] resourceArray)
        {
            List<int> splittingIndices = GcxEditor.FindAllSubArray(resourceArray, EOL);
            for (int i = 0; i < splittingIndices.Count; i++) //want to include the EOL in each item
            {
                splittingIndices[i] += 3;
            }

            List<byte[]> resourceList = new List<byte[]>();
            int positionInArray = 0;
            for (int i = 0; i < splittingIndices.Count; i++)
            {
                byte[] splitResource;
                if (i == 0)
                {
                    splitResource = new byte[splittingIndices[i]];
                }
                else if (i < splittingIndices.Count - 1)
                    splitResource = new byte[splittingIndices[i] - splittingIndices[i - 1]];
                else
                    splitResource = new byte[resourceArray.Length - splittingIndices[i - 1]];
                Array.Copy(resourceArray, positionInArray, splitResource, 0, splitResource.Length);
                resourceList.Add(splitResource);
                positionInArray += splitResource.Length;
            }

            return resourceList;
        }

        private static List<MGS2ResourceData> PrepareListOfDataToAdd(string resourceToAdd)
        {
            List<MGS2ResourceData> resourceData = new List<MGS2ResourceData>();

            BasicResource resource = Resource.LookupResource(resourceToAdd);

            if (resource is KmsResource)
            {
                MGS2ResourceData kmsData = new MGS2ResourceData();
                kmsData.Text = (resource as KmsResource).Path;
                kmsData.FileType = FileType.Kms;
                kmsData.Resource = resource;

                MGS2ResourceData cmdlData = new MGS2ResourceData();
                cmdlData.Text = (resource as KmsResource).Cmdl;
                cmdlData.FileType = FileType.Cmdl;
                cmdlData.Resource = resource;

                resourceData.Add(kmsData);
                resourceData.Add(cmdlData);
            }
            else
            {
                MGS2ResourceData mgs2ResourceData = new MGS2ResourceData();
                mgs2ResourceData.Text = resource.Path;
                mgs2ResourceData.Resource = resource;
                if (resource.Path.Contains(".ctxr"))
                    mgs2ResourceData.FileType = FileType.Ctxr;
                else if (resource.Path.Contains(".sar"))
                    mgs2ResourceData.FileType = FileType.Sar;
                else if (resource.Path.Contains(".mar"))
                    mgs2ResourceData.FileType = FileType.Mar;
                else if (resource.Path.Contains(".tri"))
                    mgs2ResourceData.FileType = FileType.Tri;
                else if (resource.Path.Contains(".cv2"))
                    mgs2ResourceData.FileType = FileType.Cv2;

                    resourceData.Add(mgs2ResourceData);
            }
            return resourceData;
        }

        private static void ReplaceStageNames(List<MGS2ResourceData> resourceData, string stageName)
        {
            foreach (MGS2ResourceData resource in resourceData)
            {
                string replacementString = $"stage/{stageName}/cache";
                resource.Text = resource.Text.Replace("stage/XXXX/cache", replacementString);
            }
        }
    }
}
