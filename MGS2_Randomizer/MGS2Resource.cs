using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGS2_Randomizer
{
    public struct MGS2Resource
    {
        //Item assets
        //TODO: convert the BasicResources that are textures to be CtxrResource
        public static BasicResource ItemBox = new BasicResource("itembox", "assets/tri/us/itembox.tri,us/stage/XXXX/cache/00883186.tri,cache/00883186.tri\r\r\n");
        public static BasicResource ItemBox2 = new BasicResource("ibox_all2", "textures/flatlist/ibox_all2.bmp.ctxr,stage/XXXX/cache/ibox_all2.bmp.ctxr,eu/stage/XXXX/cache/00883186/008e6a68.ctxr\r\r\n");
        public static KmsResource ColdMedsLabel = new KmsResource("cold_medicine_label", "assets/kms/us/cold_medicine_label_stage_a03b.kms,us/stage/XXXX/cache/00f971fb.kms,cache/00f971fb.kms\r\r\n","assets/kms/us/cold_medicine_label_stage_a03b.cmdl,us/stage/XXXX/cache/00f971fb.cmdl,eu/stage/XXXX/cache/00f971fb.cmdl\r\r\n");
        public static BasicResource ColdMedsLabelTexture = new BasicResource("coldmedicine_tx_alp.bmp", "textures/flatlist/coldmedicine_tx_alp.bmp.ctxr,stage/XXXX/cache/coldmedicine_tx_alp.bmp.ctxr,eu/stage/XXXX/cache/00573de0/00ed17f6.ctxr\r\r\n");
        public static KmsResource ThermalGogglesLabel = new KmsResource("tgl_label", "assets/kms/us/tgl_label_stage_a03b.kms,us/stage/XXXX/cache/006968d1.kms,cache/006968d1.kms\r\r\n", "assets/kms/us/tgl_label_stage_a03b.cmdl,us/stage/XXXX/cache/006968d1.cmdl,eu/stage/XXXX/cache/006968d1.cmdl\r\r\n");
        public static KmsResource GoggleIbox = new KmsResource("goggle_ibox_stage",
            path: "assets/kms/us/goggle_ibox_stage_a00c.kms,us/stage/XXXX/cache/00706bd2.kms,cache/00706bd2.kms\r\r\n",
            cmdl: "assets/kms/us/goggle_ibox_stage_a00c.cmdl,us/stage/XXXX/cache/00706bd2.cmdl,eu/stage/XXXX/cache/00706bd2.cmdl\r\r\n");
        public static BasicResource GoggleIboxTexture = new BasicResource("ibox_all4.bmp.ctxr", "textures/flatlist/ibox_all4.bmp.ctxr,stage/XXXX/cache/ibox_all4.bmp.ctxr,eu/stage/XXXX/cache/00706bd2/008e6a6a.ctxr\r\r\n");
        public static BasicResource GoggleIboxTri = new BasicResource("goggle_ibox.tri", "assets/tri/us/goggle_ibox.tri,us/stage/XXXX/cache/00706bd2.tri,cache/00706bd2.tri\r\r\n");
        public static KmsResource GoggleSh = new KmsResource("goggle_ibox_sh",
            path: "assets/kms/us/goggle_ibox_sh_stage_a00c.kms,us/stage/XXXX/cache/00eac2fd.kms,cache/00eac2fd.kms\r\r\n",
            cmdl: "assets/kms/us/goggle_ibox_sh_stage_a00c.cmdl,us/stage/XXXX/cache/00eac2fd.cmdl,eu/stage/XXXX/cache/00eac2fd.cmdl\r\r\n");
        public static KmsResource AKAmmoLabel = new KmsResource("aks_amo_label",
            path: "assets/kms/us/aks_amo_label_stage_a03b.kms,us/stage/XXXX/cache/003ce0e9.kms,cache/003ce0e9.kms\r\r\n",
            cmdl: "assets/kms/us/aks_amo_label_stage_a03b.cmdl,us/stage/XXXX/cache/003ce0e9.cmdl,eu/stage/XXXX/cache/003ce0e9.cmdl\r\r\n");
        public static KmsResource AKWeaponLabel = new KmsResource("ak_label",
            path: "assets/kms/us/ak_label_stage_a03b.kms,us/stage/XXXX/cache/00f53890.kms,cache/00f53890.kms\r\r\n",
            cmdl: "assets/kms/us/ak_label_stage_a03b.cmdl,us/stage/XXXX/cache/00f53890.cmdl,eu/stage/XXXX/cache/00f53890.cmdl\r\r\n");
        public static KmsResource MagazineIbox = new KmsResource("magazine_ibox",
            path: "assets/kms/us/magazine_ibox_stage_a03b.kms,us/stage/XXXX/cache/00ca7cd0.kms,cache/00ca7cd0.kms\r\r\n",
            cmdl: "assets/kms/us/magazine_ibox_stage_a03b.cmdl,us/stage/XXXX/cache/00ca7cd0.cmdl,eu/stage/XXXX/cache/00ca7cd0.cmdl\r\r\n");
        public static KmsResource MagazineLabel = new KmsResource("magazine_label",
            path: "assets/kms/us/magazine_label_stage_a03b.kms,us/stage/XXXX/cache/007ee425.kms,cache/007ee425.kms\r\r\n",
            cmdl: "assets/kms/us/magazine_label_stage_a03b.cmdl,us/stage/XXXX/cache/007ee425.cmdl,eu/stage/XXXX/cache/007ee425.cmdl\r\r\n");
        public static KmsResource MagazineSh = new KmsResource("magazine_sh",
            path: "assets/kms/us/magazine_sh_stage_a03b.kms,us/stage/XXXX/cache/009e33e1.kms,cache/009e33e1.kms\r\r\n",
            cmdl: "assets/kms/us/magazine_sh_stage_a03b.cmdl,us/stage/XXXX/cache/009e33e1.cmdl,eu/stage/XXXX/cache/009e33e1.cmdl\r\r\n");
        public static KmsResource C4Label = new KmsResource("cfr_label",
            path: "assets/kms/us/cfr_label_stage_a03b.kms,us/stage/XXXX/cache/00586251.kms,cache/00586251.kms\r\r\n",
            cmdl: "assets/kms/us/cfr_label_stage_a03b.cmdl,us/stage/XXXX/cache/00586251.cmdl,eu/stage/XXXX/cache/00586251.cmdl\r\r\n");
        public static KmsResource ClaymoreLabel = new KmsResource("clm_label",
            path: "assets/kms/us/clm_label_stage_a03b.kms,us/stage/XXXX/cache/00589111.kms,cache/00589111.kms\r\r\n",
            cmdl: "assets/kms/us/clm_label_stage_a03b.cmdl,us/stage/XXXX/cache/00589111.cmdl,eu/stage/XXXX/cache/00589111.cmdl\r\r\n");
        public static KmsResource DmicLabel = new KmsResource("dmp_label",
            path: "assets/kms/us/dmp_label_stage_a03b.kms,us/stage/XXXX/cache/005999d1.kms,cache/005999d1.kms\r\r\n",
            cmdl: "assets/kms/us/dmp_label_stage_a03b.cmdl,us/stage/XXXX/cache/005999d1.cmdl,eu/stage/XXXX/cache/005999d1.cmdl\r\r\n");
        public static KmsResource GrenadeLabel = new KmsResource("gre_label",
            path: "assets/kms/us/gre_label_stage_a03b.kms,us/stage/XXXX/cache/005cbf11.kms,cache/005cbf11.kms\r\r\n",
            cmdl: "assets/kms/us/gre_label_stage_a03b.cmdl,us/stage/XXXX/cache/005cbf11.cmdl,eu/stage/XXXX/cache/005cbf11.cmdl\r\r\n");
        public static KmsResource M4AmmoLabel = new KmsResource("m4_amo_label",
            path: "assets/kms/us/m4_amo_label_stage_a03b.kms,us/stage/XXXX/cache/0036d0ed.kms,cache/0036d0ed.kms\r\r\n",
            cmdl: "assets/kms/us/m4_amo_label_stage_a03b.cmdl,us/stage/XXXX/cache/0036d0ed.cmdl,eu/stage/XXXX/cache/0036d0ed.cmdl\r\r\n");
        public static KmsResource M4WeaponLabel = new KmsResource("m4_label",
            path: "assets/kms/us/m4_label_stage_a03b.kms,us/stage/XXXX/cache/00f58ad0.kms,cache/00f58ad0.kms\r\r\n",
            cmdl: "assets/kms/us/m4_label_stage_a03b.cmdl,us/stage/XXXX/cache/00f58ad0.cmdl,eu/stage/XXXX/cache/00f58ad0.cmdl\r\r\n");
        public static KmsResource NikitaAmmoLabel = new KmsResource("nkt_amo_label",
            path: "assets/kms/us/nkt_amo_label_stage_a03b.kms,us/stage/XXXX/cache/003db0ed.kms,cache/003db0ed.kms\r\r\n",
            cmdl: "assets/kms/us/nkt_amo_label_stage_a03b.cmdl,us/stage/XXXX/cache/003db0ed.cmdl,eu/stage/XXXX/cache/003db0ed.cmdl\r\r\n");
        public static KmsResource NikitaWeaponLabel = new KmsResource("nkt_label",
            path: "assets/kms/us/nkt_label_stage_a03b.kms,us/stage/XXXX/cache/00638ad1.kms,cache/00638ad1.kms\r\r\n",
            cmdl: "assets/kms/us/nkt_label_stage_a03b.cmdl,us/stage/XXXX/cache/00638ad1.cmdl,eu/stage/XXXX/cache/00638ad1.cmdl\r\r\n");
        public static KmsResource PSG1AmmoLabel = new KmsResource("psg_amo_label",
            path: "assets/kms/us/psg_amo_label_stage_a03b.kms,us/stage/XXXX/cache/003dd4b9.kms,cache/003dd4b9.kms\r\r\n",
            cmdl: "assets/kms/us/psg_amo_label_stage_a03b.cmdl,us/stage/XXXX/cache/003dd4b9.cmdl,eu/stage/XXXX/cache/003dd4b9.cmdl\r\r\n");
        public static KmsResource PSG1WeaponLabel = new KmsResource("psg_label",
            path: "assets/kms/us/psg_label_stage_a03b.kms,us/stage/XXXX/cache/0065c791.kms,cache/0065c791.kms\r\r\n",
            cmdl: "assets/kms/us/psg_label_stage_a03b.cmdl,us/stage/XXXX/cache/0065c791.cmdl,eu/stage/XXXX/cache/0065c791.cmdl\r\r\n");
        public static KmsResource RifleAmmoIbox1 = new KmsResource("006ab337",
            path: "assets/kms/us/rifle_amo_ibox_stage_a03b.kms,us/stage/XXXX/cache/006ab337.kms,cache/006ab337.kms\r\r\n",
            cmdl: "assets/kms/us/rifle_amo_ibox_stage_a03b.cmdl,us/stage/XXXX/cache/006ab337.cmdl,eu/stage/XXXX/cache/006ab337.cmdl\r\r\n");
        public static KmsResource RifleAmmoIbox2 = new KmsResource("00130222",
            path: "assets/kms/us/rifle_amo_ibox_stage_a03b.kms,us/stage/XXXX/cache/00130222.kms,cache/00130222.kms\r\r\n",
            cmdl: "assets/kms/us/rifle_amo_ibox_stage_a03b.cmdl,us/stage/XXXX/cache/00130222.cmdl,eu/stage/XXXX/cache/00130222.cmdl\r\r\n");
        public static KmsResource RilfeIbox = new KmsResource("rilfe_ibox",
            path: "assets/kms/us/rilfe_ibox.kms,us/stage/XXXX/cache/00d290b6.kms,cache/00d290b6.kms\r\r\n",
            cmdl: "assets/kms/us/rilfe_ibox.cmdl,us/stage/XXXX/cache/00d290b6.cmdl,eu/stage/XXXX/cache/00d290b6.cmdl\r\r\n");
        public static KmsResource IboxAmoNkt = new KmsResource("ibox_amo_nkt",
            path: "assets/kms/us/ibox_amo_nkt.kms,us/stage/XXXX/cache/007c8d0b.kms,cache/007c8d0b.kms\r\r\n",
            cmdl: "assets/kms/us/ibox_amo_nkt.cmdl,us/stage/XXXX/cache/007c8d0b.cmdl,eu/stage/XXXX/cache/007c8d0b.cmdl\r\r\n");
        public static KmsResource PSG1TAmmoLabel = new KmsResource("psgt_amo_label",
            path: "assets/kms/us/psgt_amo_label_stage_a03b.kms,us/stage/XXXX/cache/001dfe6e.kms,cache/001dfe6e.kms\r\r\n",
            cmdl: "assets/kms/us/psgt_amo_label_stage_a03b.cmdl,us/stage/XXXX/cache/001dfe6e.cmdl,eu/stage/XXXX/cache/001dfe6e.cmdl\r\r\n");
        public static KmsResource PSG1TWeaponLabel = new KmsResource("psg_t_label",
            path: "assets/kms/us/psg_t_label_stage_a03b.kms,us/stage/XXXX/cache/00bc2c9f.kms,cache/00bc2c9f.kms\r\r\n",
            cmdl: "assets/kms/us/psg_t_label_stage_a03b.cmdl,us/stage/XXXX/cache/00bc2c9f.cmdl,eu/stage/XXXX/cache/00bc2c9f.cmdl\r\r\n");
        public static KmsResource RGB6AmmoLabel = new KmsResource("rgb_amo_label",
            path: "assets/kms/us/rgb_amo_label_stage_a03b.kms,us/stage/XXXX/cache/003deea5.kms,cache/003deea5.kms\r\r\n",
            cmdl: "assets/kms/us/rgb_amo_label_stage_a03b.cmdl,us/stage/XXXX/cache/003deea5.cmdl,eu/stage/XXXX/cache/003deea5.cmdl\r\r\n");
        public static KmsResource RGB6WeaponLabel = new KmsResource("rgb_label",
            path: "assets/kms/us/rgb_label_stage_a03b.kms,us/stage/XXXX/cache/00676651.kms,cache/00676651.kms\r\r\n",
            cmdl: "assets/kms/us/rgb_label_stage_a03b.cmdl,us/stage/XXXX/cache/00676651.cmdl,eu/stage/XXXX/cache/00676651.cmdl\r\r\n");
        public static KmsResource StingerAmmoLabel = new KmsResource("stg_amo_label",
            path: "assets/kms/us/stg_amo_label_stage_a03b.kms,us/stage/XXXX/cache/003e0539.kms,cache/003e0539.kms\r\r\n",
            cmdl: "assets/kms/us/stg_amo_label_stage_a03b.cmdl,us/stage/XXXX/cache/003e0539.cmdl,eu/stage/XXXX/cache/003e0539.cmdl\r\r\n");
        public static KmsResource StingerWeaponLabel = new KmsResource("stg_label",
            path: "assets/kms/us/stg_label_stage_a03b.kms,us/stage/XXXX/cache/0068cf91.kms,cache/0068cf91.kms\r\r\n",
            cmdl: "assets/kms/us/stg_label_stage_a03b.cmdl,us/stage/XXXX/cache/0068cf91.cmdl,eu/stage/XXXX/cache/0068cf91.cmdl\r\r\n");
        public static KmsResource BodyArmorLabel = new KmsResource("bam_label",
            path: "assets/kms/us/bam_label_stage_a03b.kms,us/stage/XXXX/cache/00573911.kms,cache/00573911.kms\r\r\n",
            cmdl: "assets/kms/us/bam_label_stage_a03b.cmdl,us/stage/XXXX/cache/00573911.cmdl,eu/stage/XXXX/cache/00573911.cmdl\r\r\n");
        public static KmsResource DigitalCameraIbox = new KmsResource("digital_camera_ibox",
            path: "assets/kms/us/digital_camera_ibox_stage_a03b.kms,us/stage/XXXX/cache/001cd720.kms,cache/001cd720.kms\r\r\n",
            cmdl: "assets/kms/us/digital_camera_ibox_stage_a03b.cmdl,us/stage/XXXX/cache/001cd720.cmdl,eu/stage/XXXX/cache/001cd720.cmdl\r\r\n");
        public static BasicResource DigitalCameraBoxTexture = new BasicResource("degital_camera","textures/flatlist/degital_camera.bmp.ctxr,stage/XXXX/cache/degital_camera.bmp.ctxr,eu/stage/XXXX/cache/00883186/00fb2060.ctxr\r\r\n");
        public static KmsResource DigitalCameraLabel = new KmsResource("digital_camera_label",
            path: "assets/kms/us/digital_camera_label_stage_a03b.kms,us/stage/XXXX/cache/00ca2e0f.kms,cache/00ca2e0f.kms\r\r\n",
            cmdl: "assets/kms/us/digital_camera_label_stage_a03b.cmdl,us/stage/XXXX/cache/00ca2e0f.cmdl,eu/stage/XXXX/cache/00ca2e0f.cmdl\r\r\n");
        public static KmsResource DigitalCameraSh = new KmsResource("digital_camera_sh",
            path: "assets/kms/us/digital_camera_sh_stage_a03b.kms,us/stage/XXXX/cache/00320878.kms,cache/00320878.kms\r\r\n",
            cmdl: "assets/kms/us/digital_camera_sh_stage_a03b.cmdl,us/stage/XXXX/cache/00320878.cmdl,eu/stage/XXXX/cache/00320878.cmdl\r\r\n");
        public static KmsResource PentazeminLabel = new KmsResource("dzp2_label",
            path: "assets/kms/us/dzp2_label_stage_a03b.kms,us/stage/XXXX/cache/00efa25d.kms,cache/00efa25d.kms\r\r\n",
            cmdl: "assets/kms/us/dzp2_label_stage_a03b.cmdl,us/stage/XXXX/cache/00efa25d.cmdl,eu/stage/XXXX/cache/00efa25d.cmdl\r\r\n");
        public static BasicResource Dzp2TxAlpTexture = new BasicResource("dzp2_tx_alp","textures/flatlist/dzp2_tx_alp.bmp.ctxr,stage/XXXX/cache/dzp2_tx_alp.bmp.ctxr,eu/stage/XXXX/cache/00573de0/0062bc3f.ctxr\r\r\n");
        public static KmsResource SensorBLabel = new KmsResource("bsn_b_label",
            path: "assets/kms/us/bsn_b_label_stage_a03b.kms,us/stage/XXXX/cache/00c327e7.kms,cache/00c327e7.kms\r\r\n",
            cmdl: "assets/kms/us/bsn_b_label_stage_a03b.cmdl,us/stage/XXXX/cache/00c327e7.cmdl,eu/stage/XXXX/cache/00c327e7.cmdl\r\r\n");
        public static KmsResource SocomSuppressorLabel = new KmsResource("scm_sp_label",
            path: "assets/kms/us/scm_sp_label_stage_a03b.kms,us/stage/XXXX/cache/00f504ea.kms,cache/00f504ea.kms\r\r\n",
            cmdl: "assets/kms/us/scm_sp_label_stage_a03b.cmdl,us/stage/XXXX/cache/00f504ea.cmdl,eu/stage/XXXX/cache/00f504ea.cmdl\r\r\n");
        public static KmsResource MineDetectorLabel = new KmsResource("mnd_label",
            path: "assets/kms/us/mnd_label_stage_a03b.kms,us/stage/XXXX/cache/00629ed1.kms,cache/00629ed1.kms\r\r\n",
            cmdl: "assets/kms/us/mnd_label_stage_a03b.cmdl,us/stage/XXXX/cache/00629ed1.cmdl,eu/stage/XXXX/cache/00629ed1.cmdl\r\r\n");
        public static KmsResource NVGLabel = new KmsResource("ngl_label",
            path: "assets/kms/us/ngl_label_stage_a03b.kms,us/stage/XXXX/cache/006368d1.kms,cache/006368d1.kms\r\r\n",
            cmdl: "assets/kms/us/ngl_label_stage_a03b.cmdl,us/stage/XXXX/cache/006368d1.cmdl,eu/stage/XXXX/cache/006368d1.cmdl\r\r\n");
        public static KmsResource RifleAmmoIbox = new KmsResource("rifle_amo_ibox",
            path: "assets/kms/us/rifle_amo_ibox_stage_a03b.kms,us/stage/XXXX/cache/0012ff3a.kms,cache/0012ff3a.kms\r\r\n",
            cmdl: "assets/kms/us/rifle_amo_ibox_stage_a03b.cmdl,us/stage/XXXX/cache/0012ff3a.cmdl,eu/stage/XXXX/cache/0012ff3a.cmdl\r\r\n"); //TODO: there are at least 3 of these referenced in w22a. what is going on with this
        public static KmsResource RifleAmmoSh = new KmsResource("handgun_amo_ibox",
            path: "assets/kms/us/handgun_amo_ibox_sh_stage_a03b.kms,us/stage/XXXX/cache/009e9447.kms,cache/009e9447.kms\r\r\n",
            cmdl: "assets/kms/us/handgun_amo_ibox_sh_stage_a03b.cmdl,us/stage/XXXX/cache/009e9447.cmdl,eu/stage/XXXX/cache/009e9447.cmdl\r\r\n"); //This is NOT a mistake on my part, this is Konami/Bluepoint's doing. This is correct to the game files
        public static KmsResource RifleIbox = new KmsResource("rifle_ibox_stage",
            path: "assets/kms/us/rifle_ibox_stage_a03b.kms,us/stage/XXXX/cache/00d26236.kms,cache/00d26236.kms\r\r\n",
            cmdl: "assets/kms/us/rifle_ibox_stage_a03b.cmdl,us/stage/XXXX/cache/00d26236.cmdl,eu/stage/XXXX/cache/00d26236.cmdl\r\r\n");
        public static BasicResource RifleIboxTexture = new BasicResource("rifle_box","textures/flatlist/rifle_ibox.bmp_94bca08db682d231ae1d48d2b6385598.ctxr,stage/XXXX/cache/rifle_ibox.bmp_94bca08db682d231ae1d48d2b6385598.ctxr,eu/stage/XXXX/cache/00883186/00d26236.ctxr\r\r\n");
        public static KmsResource RifleSh = new KmsResource("rifle_ibox_sh",
            path: "assets/kms/us/rifle_ibox_sh_stage_a03b.kms,us/stage/XXXX/cache/001cf3f9.kms,cache/001cf3f9.kms\r\r\n",
            cmdl: "assets/kms/us/rifle_ibox_sh_stage_a03b.cmdl,us/stage/XXXX/cache/001cf3f9.cmdl,eu/stage/XXXX/cache/001cf3f9.cmdl\r\r\n");
        public static KmsResource LauncherAmmoIbox = new KmsResource("launcher_amo_ibox_stage",
            path: "assets/kms/us/launcher_amo_ibox_stage_a03b.kms,us/stage/XXXX/cache/00eb0f44.kms,cache/00eb0f44.kms\r\r\n",
            cmdl: "assets/kms/us/launcher_amo_ibox_stage_a03b.cmdl,us/stage/XXXX/cache/00eb0f44.cmdl,eu/stage/XXXX/cache/00eb0f44.cmdl\r\r\n");
        public static KmsResource LauncherAmmoSh = new KmsResource("launcher_amo_ibox_sh",
            path: "assets/kms/us/launcher_amo_ibox_sh_stage_a03b.kms,us/stage/XXXX/cache/00a4004f.kms,cache/00a4004f.kms\r\r\n",
            cmdl: "assets/kms/us/launcher_amo_ibox_sh_stage_a03b.cmdl,us/stage/XXXX/cache/00a4004f.cmdl,eu/stage/XXXX/cache/00a4004f.cmdl\r\r\n");
        public static BasicResource LauncherAmmoSideTexture = new BasicResource("launcher_ammo_side","textures/flatlist/launcher_ammo_side.bmp.ctxr,stage/XXXX/cache/launcher_ammo_side.bmp.ctxr,eu/stage/XXXX/cache/00883186/00ca4e21.ctxr\r\r\n");
        public static KmsResource LauncherIbox = new KmsResource("launcher_ibox_stage",
            path: "assets/kms/us/launcher_ibox_stage_a03b.kms,us/stage/XXXX/cache/005362e4.kms,cache/005362e4.kms\r\r\n",
            cmdl: "assets/kms/us/launcher_ibox_stage_a03b.cmdl,us/stage/XXXX/cache/005362e4.cmdl,eu/stage/XXXX/cache/005362e4.cmdl\r\r\n");
        public static BasicResource LauncherIboxTexture = new BasicResource("launcher_ibox","textures/flatlist/launcher_ibox.bmp.ctxr,stage/XXXX/cache/launcher_ibox.bmp.ctxr,eu/stage/XXXX/cache/00883186/005362e4.ctxr\r\r\n");
        public static KmsResource LauncherSh = new KmsResource("launcher_ibox_sh",
            path: "assets/kms/us/launcher_ibox_sh_stage_a03b.kms,us/stage/XXXX/cache/0073b479.kms,cache/0073b479.kms\r\r\n",
            cmdl: "assets/kms/us/launcher_ibox_sh_stage_a03b.cmdl,us/stage/XXXX/cache/0073b479.cmdl,eu/stage/XXXX/cache/0073b479.cmdl\r\r\n");
        public static KmsResource Box2Ibox = new KmsResource("box2_ibox",
            path: "assets/kms/us/box2_ibox_stage_a03b.kms,us/stage/XXXX/cache/008bacc2.kms,cache/008bacc2.kms\r\r\n",
            cmdl: "assets/kms/us/box2_ibox_stage_a03b.cmdl,us/stage/XXXX/cache/008bacc2.cmdl,eu/stage/XXXX/cache/008bacc2.cmdl\r\r\n");
        public static BasicResource Ibox2TxAllTexture = new BasicResource("ibox2_tx_all_alp.bmp","textures/flatlist/ibox2_tx_all_alp.bmp.ctxr,stage/XXXX/cache/ibox2_tx_all_alp.bmp.ctxr,eu/stage/XXXX/cache/00573de0/0051c0fb.ctxr\r\r\n");
        public static KmsResource Box2Sh = new KmsResource("box2_ibox_sh",
            path: "assets/kms/us/box2_ibox_sh_stage_a03b.kms,us/stage/XXXX/cache/0062d09e.kms,cache/0062d09e.kms\r\r\n",
            cmdl: "assets/kms/us/box2_ibox_sh_stage_a03b.cmdl,us/stage/XXXX/cache/0062d09e.cmdl,eu/stage/XXXX/cache/0062d09e.cmdl\r\r\n");
        public static KmsResource CbxLabel = new KmsResource("cbx_label",
            path: "assets/kms/us/cbx_label_stage_a03b.kms,us/stage/XXXX/cache/005843d1.kms,cache/005843d1.kms\r\r\n",
            cmdl: "assets/kms/us/cbx_label_stage_a03b.cmdl,us/stage/XXXX/cache/005843d1.cmdl,eu/stage/XXXX/cache/005843d1.cmdl\r\r\n");
        public static KmsResource DetectorIbox = new KmsResource("detector_ibox_stage",
            path: "assets/kms/us/detector_ibox_stage_a03b.kms,us/stage/XXXX/cache/0033475f.kms,cache/0033475f.kms\r\r\n",
            cmdl: "assets/kms/us/detector_ibox_stage_a03b.cmdl,us/stage/XXXX/cache/0033475f.cmdl,eu/stage/XXXX/cache/0033475f.cmdl\r\r\n");
        public static KmsResource DetectorSh = new KmsResource("detector_ibox_sh",
            path: "assets/kms/us/detector_ibox_sh_stage_a03b.kms,us/stage/XXXX/cache/00b1246b.kms,cache/00b1246b.kms\r\r\n",
            cmdl: "assets/kms/us/detector_ibox_sh_stage_a03b.cmdl,us/stage/XXXX/cache/00b1246b.cmdl,eu/stage/XXXX/cache/00b1246b.cmdl\r\r\n");
        public static KmsResource DmicIbox = new KmsResource("box_ibox_stage",
            path: "assets/kms/us/box_ibox_stage_a03b.kms,us/stage/XXXX/cache/0029430e.kms,cache/0029430e.kms\r\r\n",
            cmdl: "assets/kms/us/box_ibox_stage_a03b.cmdl,us/stage/XXXX/cache/0029430e.cmdl,eu/stage/XXXX/cache/0029430e.cmdl\r\r\n");
        public static BasicResource DMicLabelTexture = new BasicResource("dmp_ibx_label_alp.bmp","textures/flatlist/dmp_ibx_label_alp.bmp.ctxr,stage/XXXX/cache/dmp_ibx_label_alp.bmp.ctxr,eu/stage/XXXX/cache/00573de0/00055db2.ctxr\r\r\n");
        public static KmsResource DmicSh = new KmsResource("box_ibox_sh",
            path: "assets/kms/us/box_ibox_sh_stage_a03b.kms,us/stage/XXXX/cache/00889f69.kms,cache/00889f69.kms\r\r\n",
            cmdl: "assets/kms/us/box_ibox_sh_stage_a03b.cmdl,us/stage/XXXX/cache/00889f69.cmdl,eu/stage/XXXX/cache/00889f69.cmdl\r\r\n");
        public static KmsResource RationIbox = new KmsResource("ration_ibox_stage",
            path: "assets/kms/us/ration_ibox_stage_a03b.kms,us/stage/XXXX/cache/00bd7cce.kms,cache/00bd7cce.kms\r\r\n",
            cmdl: "assets/kms/us/ration_ibox_stage_a03b.cmdl,us/stage/XXXX/cache/00bd7cce.cmdl,eu/stage/XXXX/cache/00bd7cce.cmdl\r\r\n");
        public static BasicResource RationTexture = new BasicResource("ration_box.bmp","textures/flatlist/ration_box.bmp.ctxr,stage/XXXX/cache/ration_box.bmp.ctxr,eu/stage/XXXX/cache/00883186/00b5d18b.ctxr\r\r\n");
        public static KmsResource M9AmmoLabel = new KmsResource("m92_amo_label",
            path: "assets/kms/us/m92_amo_label_stage_a03b.kms,us/stage/XXXX/cache/003d86e5.kms,cache/003d86e5.kms\r\r\n",
            cmdl: "assets/kms/us/m92_amo_label_stage_a03b.cmdl,us/stage/XXXX/cache/003d86e5.cmdl,eu/stage/XXXX/cache/003d86e5.cmdl\r\r\n");
        public static KmsResource M9WeaponLabel = new KmsResource("m92_label",
            path: "assets/kms/us/m92_label_stage_a03b.kms,us/stage/XXXX/cache/0060ea51.kms,cache/0060ea51.kms\r\r\n",
            cmdl: "assets/kms/us/m92_label_stage_a03b.cmdl,us/stage/XXXX/cache/0060ea51.cmdl,eu/stage/XXXX/cache/0060ea51.cmdl\r\r\n");
        public static KmsResource StunLabel = new KmsResource("sgr_label",
            path: "assets/kms/us/sgr_label_stage_a03b.kms,us/stage/XXXX/cache/00686a51.kms,cache/00686a51.kms\r\r\n",
            cmdl: "assets/kms/us/sgr_label_stage_a03b.cmdl,us/stage/XXXX/cache/00686a51.cmdl,eu/stage/XXXX/cache/00686a51.cmdl\r\r\n");
        public static KmsResource BandageLabel = new KmsResource("sbs_label",
            path: "assets/kms/us/sbs_label_stage_a03b.kms,us/stage/XXXX/cache/00684291.kms,cache/00684291.kms\r\r\n",
            cmdl: "assets/kms/us/sbs_label_stage_a03b.cmdl,us/stage/XXXX/cache/00684291.cmdl,eu/stage/XXXX/cache/00684291.cmdl\r\r\n");
        public static KmsResource ShaverLabel = new KmsResource("shv_label",
            path: "assets/kms/us/shv_label_stage_a03b.kms,us/stage/XXXX/cache/00687351.kms,cache/00687351.kms\r\r\n",
            cmdl: "assets/kms/us/shv_label_stage_a03b.cmdl,us/stage/XXXX/cache/00687351.cmdl,eu/stage/XXXX/cache/00687351.cmdl\r\r\n");
        public static KmsResource MedicineIbox = new KmsResource("medicine_ibox_stage",
            path: "assets/kms/us/medicine_ibox_stage_a03b.kms,us/stage/XXXX/cache/00b37ec5.kms,cache/00b37ec5.kms\r\r\n",
            cmdl: "assets/kms/us/medicine_ibox_stage_a03b.cmdl,us/stage/XXXX/cache/00b37ec5.cmdl,eu/stage/XXXX/cache/00b37ec5.cmdl\r\r\n");
        public static BasicResource MedicineBoxTexture = new BasicResource("medicine_box","textures/flatlist/medicine_box.bmp.ctxr,stage/XXXX/cache/medicine_box.bmp.ctxr,eu/stage/XXXX/cache/00883186/006d819b.ctxr\r\r\n");
        public static KmsResource MedicineSh = new KmsResource("medicine_ibox_sh",
            path: "assets/kms/us/medicine_ibox_sh_stage_a03b.kms,us/stage/XXXX/cache/00646487.kms,cache/00646487.kms\r\r\n",
            cmdl: "assets/kms/us/medicine_ibox_sh_stage_a03b.cmdl,us/stage/XXXX/cache/00646487.cmdl,eu/stage/XXXX/cache/00646487.cmdl\r\r\n");
        public static KmsResource HandgunIbox = new KmsResource("handgun_ibox_stage",
            path: "assets/kms/us/handgun_ibox_stage_a03b.kms,us/stage/XXXX/cache/004da20c.kms,cache/004da20c.kms\r\r\n",
            cmdl: "assets/kms/us/handgun_ibox_stage_a03b.cmdl,us/stage/XXXX/cache/004da20c.cmdl,eu/stage/XXXX/cache/004da20c.cmdl\r\r\n");
        public static KmsResource HandgunSh = new KmsResource("handgun_ibox_sh",
            path: "assets/kms/us/handgun_ibox_sh_stage_a03b.kms,us/stage/XXXX/cache/0007b199.kms,cache/0007b199.kms\r\r\n",
            cmdl: "assets/kms/us/handgun_ibox_sh_stage_a03b.cmdl,us/stage/XXXX/cache/0007b199.cmdl,eu/stage/XXXX/cache/0007b199.cmdl\r\r\n");
        public static KmsResource ChaffLabel = new KmsResource("cgr_label",
            path: "assets/kms/us/cgr_label_stage_a03b.kms,us/stage/XXXX/cache/00586a51.kms,cache/00586a51.kms\r\r\n",
            cmdl: "assets/kms/us/cgr_label_stage_a03b.cmdl,us/stage/XXXX/cache/00586a51.cmdl,eu/stage/XXXX/cache/00586a51.cmdl\r\r\n");
        public static KmsResource SocomAmmoLabel = new KmsResource("scm_amo_label",
            path: "assets/kms/us/scm_amo_label_stage_a03b.kms,us/stage/XXXX/cache/003dfcd1.kms,cache/003dfcd1.kms\r\r\n",
            cmdl: "assets/kms/us/scm_amo_label_stage_a03b.cmdl,us/stage/XXXX/cache/003dfcd1.cmdl,eu/stage/XXXX/cache/003dfcd1.cmdl\r\r\n");
        public static KmsResource GrenadeIbox = new KmsResource("grenade_ibox_stage",
            path: "assets/kms/us/grenade_ibox_stage_a03b.kms,us/stage/XXXX/cache/00376d7d.kms,cache/00376d7d.kms\r\r\n",
            cmdl: "assets/kms/us/grenade_ibox_stage_a03b.cmdl,us/stage/XXXX/cache/00376d7d.cmdl,eu/stage/XXXX/cache/00376d7d.cmdl\r\r\n");
        public static KmsResource GrenadeSh = new KmsResource("grenade_ibox_sh",
            path: "assets/kms/us/grenade_ibox_sh_stage_a03b.kms,us/stage/XXXX/cache/00c0267e.kms,cache/00c0267e.kms\r\r\n",
            cmdl: "assets/kms/us/grenade_ibox_sh_stage_a03b.cmdl,us/stage/XXXX/cache/00c0267e.cmdl,eu/stage/XXXX/cache/00c0267e.cmdl\r\r\n");
        public static KmsResource HandgunAmmoIbox = new KmsResource("rifle_amo_ibox_stage",
            path: "assets/kms/us/rifle_amo_ibox_stage_a03b.kms,us/stage/XXXX/cache/006ab337.kms,cache/006ab337.kms\r\r\n",
            cmdl: "assets/kms/us/rifle_amo_ibox_stage_a03b.cmdl,us/stage/XXXX/cache/006ab337.cmdl,eu/stage/XXXX/cache/006ab337.cmdl\r\r\n"); //again, this is not a mistake on our part. This was done by Konami/Bluepoint
        public static KmsResource HandgunAmmoSh = new KmsResource("handgun_amo_ibox_sh",
            path: "assets/kms/us/handgun_amo_ibox_sh_stage_a03b.kms,us/stage/XXXX/cache/009d4021.kms,cache/009d4021.kms\r\r\n",
            cmdl: "assets/kms/us/handgun_amo_ibox_sh_stage_a03b.cmdl,us/stage/XXXX/cache/009d4021.cmdl,eu/stage/XXXX/cache/009d4021.cmdl\r\r\n");
        public static KmsResource RationSh = new KmsResource("ration_ibox_sh",
            path: "assets/kms/us/ration_ibox_sh_stage_a03b.kms,us/stage/XXXX/cache/0068e986.kms,cache/0068e986.kms\r\r\n",
            cmdl: "assets/kms/us/ration_ibox_sh_stage_a03b.cmdl,us/stage/XXXX/cache/0068e986.cmdl,eu/stage/XXXX/cache/0068e986.cmdl\r\r\n");
        public static KmsResource RationLabel = new KmsResource("rtn_label",
            path: "assets/kms/us/rtn_label_stage_a03b.kms,us/stage/XXXX/cache/0067d151.kms,cache/0067d151.kms\r\r\n",
            cmdl: "assets/kms/us/rtn_label_stage_a03b.cmdl,us/stage/XXXX/cache/0067d151.cmdl,eu/stage/XXXX/cache/0067d151.cmdl\r\r\n");
        public static KmsResource AKSuppressorLabel = new KmsResource("ak_sp_label",
            path: "assets/kms/us/ak_sp_label_stage_a03b.kms,us/stage/XXXX/cache/00b4cb62.kms,cache/00b4cb62.kms\r\r\n",
            cmdl: "assets/kms/us/ak_sp_label_stage_a03b.cmdl,us/stage/XXXX/cache/00b4cb62.cmdl,eu/stage/XXXX/cache/00b4cb62.cmdl\r\r\n");
        public static KmsResource CoolantSprayLabel = new KmsResource("cls_label",
            path: "assets/kms/us/cls_label.kms,us/stage/XXXX/cache/00589291.kms,cache/00589291.kms\r\r\n",
            cmdl: "assets/kms/us/cls_label.cmdl,us/stage/XXXX/cache/00589291.cmdl,eu/stage/XXXX/cache/00589291.cmdl\r\r\n");
        public static KmsResource UspLabel = new KmsResource("usp_label",
            path: "assets/kms/us/usp_label_stage_a03b.kms,us/stage/XXXX/cache/006ac9d1.kms,cache/006ac9d1.kms\r\r\n",
            cmdl: "assets/kms/us/usp_label_stage_a03b.cmdl,us/stage/XXXX/cache/006ac9d1.cmdl,eu/stage/XXXX/cache/006ac9d1.cmdl\r\r\n");
        public static KmsResource SocomLabel = new KmsResource("scm_label",
            path: "assets/kms/us/scm_label.kms,us/stage/XXXX/cache/00684911.kms,cache/00684911.kms\r\r\n",
            cmdl: "assets/kms/us/scm_label.cmdl,us/stage/XXXX/cache/00684911.cmdl,eu/stage/XXXX/cache/00684911.cmdl\r\r\n");
        public static KmsResource CigarettesLabel = new KmsResource("cigarette_label",
            path: "assets/kms/us/cigarette_label.kms,us/stage/XXXX/cache/00a2717f.kms,cache/00a2717f.kms\r\r\n",
            cmdl: "assets/kms/us/cigarette_label.cmdl,us/stage/XXXX/cache/00a2717f.cmdl,eu/stage/XXXX/cache/00a2717f.cmdl\r\r\n");
        public static KmsResource CigarettesIbox = new KmsResource("cigarette_ibox",
            path: "assets/kms/us/cigarette_ibox.kms,us/stage/XXXX/cache/009b993b.kms,cache/009b993b.kms\r\r\n",
            cmdl: "assets/kms/us/cigarette_ibox.cmdl,us/stage/XXXX/cache/009b993b.cmdl,eu/stage/XXXX/cache/009b993b.cmdl\r\r\n");
        public static KmsResource CigarettesIboxSh = new KmsResource("cigarette_sh",
            path: "assets/kms/us/cigarette_sh.kms,us/stage/XXXX/cache/00b8e828.kms,cache/00b8e828.kms\r\r\n",
            cmdl: "assets/kms/us/cigarette_sh.cmdl,us/stage/XXXX/cache/00b8e828.cmdl,eu/stage/XXXX/cache/00b8e828.cmdl\r\r\n");
        public static KmsResource SensorALabel = new KmsResource("bsn_a_label",
            path: "assets/kms/us/bsn_a_label.kms,us/stage/XXXX/cache/00c327a7.kms,cache/00c327a7.kms\r\r\n",
            cmdl: "assets/kms/us/bsn_a_label.cmdl,us/stage/XXXX/cache/00c327a7.cmdl,eu/stage/XXXX/cache/00c327a7.cmdl\r\r\n");
        public static KmsResource APSensorIbox = new KmsResource("a_p_sensor_ibox.",
            path: "assets/kms/us/a_p_sensor_ibox.kms,us/stage/XXXX/cache/003cfc74.kms,cache/003cfc74.kms\r\r\n",
            cmdl: "assets/kms/us/a_p_sensor_ibox.cmdl,us/stage/XXXX/cache/003cfc74.cmdl,eu/stage/XXXX/cache/003cfc74.cmdl\r\r\n");
        public static KmsResource APSensorLabel = new KmsResource("a_p_sensor_ibox_label",
            path: "assets/kms/us/a_p_sensor_ibox_label.kms,us/stage/XXXX/cache/003132e0.kms,cache/003132e0.kms\r\r\n",
            cmdl: "assets/kms/us/a_p_sensor_ibox_label.cmdl,us/stage/XXXX/cache/003132e0.cmdl,eu/stage/XXXX/cache/003132e0.cmdl\r\r\n");
        public static KmsResource ScopeCustomBox = new KmsResource("sougan",
            path: "assets/kms/us/sougan.kms,us/stage/XXXX/cache/002c297b.kms,cache/002c297b.kms\r\r\n",
            cmdl: "assets/kms/us/sougan.cmdl,us/stage/XXXX/cache/002c297b.cmdl,eu/stage/XXXX/cache/002c297b.cmdl\r\r\n");

        //Shield guard assets
        public static KmsResource ShlLit2 = new KmsResource("shl_lit2",
            path: "assets/kms/us/shl_lit2.kms,us/stage/XXXX/cache/002b6590.kms,cache/002b6590.kms\r\r\n",
            cmdl: "assets/kms/us/shl_lit2.cmdl,us/stage/XXXX/cache/002b6590.cmdl,eu/stage/XXXX/cache/002b6590.cmdl\r\r\n");
        public static KmsResource ShlLit1 = new KmsResource("shl_lit1",
            path: "assets/kms/us/shl_lit1.kms,us/stage/XXXX/cache/002b658f.kms,cache/002b658f.kms\r\r\n",
            cmdl: "assets/kms/us/shl_lit1.cmdl,us/stage/XXXX/cache/002b658f.cmdl,eu/stage/XXXX/cache/002b658f.cmdl\r\r\n");
        public static KmsResource ShlFrg1 = new KmsResource("shl_frg1",
            path: "assets/kms/us/shl_frg1.kms,us/stage/XXXX/cache/002887ef.kms,cache/002887ef.kms\r\r\n",
            cmdl: "assets/kms/us/shl_frg1.cmdl,us/stage/XXXX/cache/002887ef.cmdl,eu/stage/XXXX/cache/002887ef.cmdl\r\r\n");
        public static KmsResource ShlChi5 = new KmsResource("shl_chi5",
            path: "assets/kms/us/shl_chi5.kms,us/stage/XXXX/cache/0026e033.kms,cache/0026e033.kms\r\r\n",
            cmdl: "assets/kms/us/shl_chi5.cmdl,us/stage/XXXX/cache/0026e033.cmdl,eu/stage/XXXX/cache/0026e033.cmdl\r\r\n");
        public static KmsResource ShlChi4 = new KmsResource("shl_chi4",
            path: "assets/kms/us/shl_chi4.kms,us/stage/XXXX/cache/0026e032.kms,cache/0026e032.kms\r\r\n",
            cmdl: "assets/kms/us/shl_chi4.cmdl,us/stage/XXXX/cache/0026e032.cmdl,eu/stage/XXXX/cache/0026e032.cmdl\r\r\n");
        public static KmsResource ShlChi3 = new KmsResource("shl_chi3",
            path: "assets/kms/us/shl_chi3.kms,us/stage/XXXX/cache/0026e031.kms,cache/0026e031.kms\r\r\n",
            cmdl: "assets/kms/us/shl_chi3.cmdl,us/stage/XXXX/cache/0026e031.cmdl,eu/stage/XXXX/cache/0026e031.cmdl\r\r\n");
        public static KmsResource ShlChi2 = new KmsResource("shl_chi2",
            path: "assets/kms/us/shl_chi2.kms,us/stage/XXXX/cache/0026e030.kms,cache/0026e030.kms\r\r\n",
            cmdl: "assets/kms/us/shl_chi2.cmdl,us/stage/XXXX/cache/0026e030.cmdl,eu/stage/XXXX/cache/0026e030.cmdl\r\r\n");
        public static KmsResource ShlChi1 = new KmsResource("shl_chi1",
            path: "assets/kms/us/shl_chi1.kms,us/stage/XXXX/cache/0026e02f.kms,cache/0026e02f.kms\r\r\n",
            cmdl: "assets/kms/us/shl_chi1.cmdl,us/stage/XXXX/cache/0026e02f.cmdl,eu/stage/XXXX/cache/0026e02f.cmdl\r\r\n");
        public static KmsResource ShlBul6 = new KmsResource("shl_bul6",
            path: "assets/kms/us/shl_bul6.kms,us/stage/XXXX/cache/00269494.kms,cache/00269494.kms\r\r\n",
            cmdl: "assets/kms/us/shl_bul6.cmdl,us/stage/XXXX/cache/00269494.cmdl,eu/stage/XXXX/cache/00269494.cmdl\r\r\n");
        public static KmsResource ShlBul5 = new KmsResource("shl_bul5",
            path: "assets/kms/us/shl_bul5.kms,us/stage/XXXX/cache/00269493.kms,cache/00269493.kms\r\r\n",
            cmdl: "assets/kms/us/shl_bul5.cmdl,us/stage/XXXX/cache/00269493.cmdl,eu/stage/XXXX/cache/00269493.cmdl\r\r\n");
        public static KmsResource ShlBul4 = new KmsResource("shl_bul4",
            path: "assets/kms/us/shl_bul4.kms,us/stage/XXXX/cache/00269492.kms,cache/00269492.kms\r\r\n",
            cmdl: "assets/kms/us/shl_bul4.cmdl,us/stage/XXXX/cache/00269492.cmdl,eu/stage/XXXX/cache/00269492.cmdl\r\r\n");
        public static KmsResource ShlBul3 = new KmsResource("shl_bul3",
            path: "assets/kms/us/shl_bul3.kms,us/stage/XXXX/cache/00269491.kms,cache/00269491.kms\r\r\n",
            cmdl: "assets/kms/us/shl_bul3.cmdl,us/stage/XXXX/cache/00269491.cmdl,eu/stage/XXXX/cache/00269491.cmdl\r\r\n");
        public static KmsResource ShlBul2 = new KmsResource("shl_bul2",
            path: "assets/kms/us/shl_bul2.kms,us/stage/XXXX/cache/00269490.kms,cache/00269490.kms\r\r\n",
            cmdl: "assets/kms/us/shl_bul2.cmdl,us/stage/XXXX/cache/00269490.cmdl,eu/stage/XXXX/cache/00269490.cmdl\r\r\n");
        public static KmsResource ShlBul1 = new KmsResource("shl_bul1",
            path: "assets/kms/us/shl_bul1.kms,us/stage/XXXX/cache/0026948f.kms,cache/0026948f.kms\r\r\n",
            cmdl: "assets/kms/us/shl_bul1.cmdl,us/stage/XXXX/cache/0026948f.cmdl,eu/stage/XXXX/cache/0026948f.cmdl\r\r\n");
        public static KmsResource ShlBlu3 = new KmsResource("shl_blu3",
            path: "assets/kms/us/shl_blu3.kms,us/stage/XXXX/cache/002671b1.kms,cache/002671b1.kms\r\r\n",
            cmdl: "assets/kms/us/shl_blu3.cmdl,us/stage/XXXX/cache/002671b1.cmdl,eu/stage/XXXX/cache/002671b1.cmdl\r\r\n");
        public static KmsResource ShlBlu2 = new KmsResource("shl_blu2",
            path: "assets/kms/us/shl_blu2.kms,us/stage/XXXX/cache/002671b0.kms,cache/002671b0.kms\r\r\n",
            cmdl: "assets/kms/us/shl_blu2.cmdl,us/stage/XXXX/cache/002671b0.cmdl,eu/stage/XXXX/cache/002671b0.cmdl\r\r\n");
        public static KmsResource ShlBlu1 = new KmsResource("shl_blu1",
            path: "assets/kms/us/shl_blu1.kms,us/stage/XXXX/cache/002671af.kms,cache/002671af.kms\r\r\n",
            cmdl: "assets/kms/us/shl_blu1.cmdl,us/stage/XXXX/cache/002671af.cmdl,eu/stage/XXXX/cache/002671af.cmdl\r\r\n");
        public static KmsResource ShlBlr3 = new KmsResource("shl_blr3",
            path: "assets/kms/us/shl_blr3.kms,us/stage/XXXX/cache/00267151.kms,cache/00267151.kms\r\r\n",
            cmdl: "assets/kms/us/shl_blr3.cmdl,us/stage/XXXX/cache/00267151.cmdl,eu/stage/XXXX/cache/00267151.cmdl\r\r\n");
        public static KmsResource ShlBlr2 = new KmsResource("shl_blr2",
            path: "assets/kms/us/shl_blr2.kms,us/stage/XXXX/cache/00267150.kms,cache/00267150.kms\r\r\n",
            cmdl: "assets/kms/us/shl_blr2.cmdl,us/stage/XXXX/cache/00267150.cmdl,eu/stage/XXXX/cache/00267150.cmdl\r\r\n");
        public static KmsResource ShlBlr1 = new KmsResource("shl_blr1",
            path: "assets/kms/us/shl_blr1.kms,us/stage/XXXX/cache/0026714f.kms,cache/0026714f.kms\r\r\n",
            cmdl: "assets/kms/us/shl_blr1.cmdl,us/stage/XXXX/cache/0026714f.cmdl,eu/stage/XXXX/cache/0026714f.cmdl\r\r\n");
        public static KmsResource ShlBll3 = new KmsResource("shl_bll3",
            path: "assets/kms/us/shl_bll3.kms,us/stage/XXXX/cache/00267091.kms,cache/00267091.kms\r\r\n",
            cmdl: "assets/kms/us/shl_bll3.cmdl,us/stage/XXXX/cache/00267091.cmdl,eu/stage/XXXX/cache/00267091.cmdl\r\r\n");
        public static KmsResource ShlBll2 = new KmsResource("shl_bll2",
            path: "assets/kms/us/shl_bll2.kms,us/stage/XXXX/cache/00267090.kms,cache/00267090.kms\r\r\n",
            cmdl: "assets/kms/us/shl_bll2.cmdl,us/stage/XXXX/cache/00267090.cmdl,eu/stage/XXXX/cache/00267090.cmdl\r\r\n");
        public static KmsResource ShlBll1 = new KmsResource("shl_bll1",
            path: "assets/kms/us/shl_bll1.kms,us/stage/XXXX/cache/0026708f.kms,cache/0026708f.kms\r\r\n",
            cmdl: "assets/kms/us/shl_bll1.cmdl,us/stage/XXXX/cache/0026708f.cmdl,eu/stage/XXXX/cache/0026708f.cmdl\r\r\n");
        public static KmsResource ShlBld3 = new KmsResource("shl_bld3",
            path: "assets/kms/us/shl_bld3.kms,us/stage/XXXX/cache/00266f91.kms,cache/00266f91.kms\r\r\n",
            cmdl: "assets/kms/us/shl_bld3.cmdl,us/stage/XXXX/cache/00266f91.cmdl,eu/stage/XXXX/cache/00266f91.cmdl\r\r\n");
        public static KmsResource ShlBld2 = new KmsResource("shl_bld2",
            path: "assets/kms/us/shl_bld2.kms,us/stage/XXXX/cache/00266f90.kms,cache/00266f90.kms\r\r\n",
            cmdl: "assets/kms/us/shl_bld2.cmdl,us/stage/XXXX/cache/00266f90.cmdl,eu/stage/XXXX/cache/00266f90.cmdl\r\r\n");
        public static KmsResource ShlBld1 = new KmsResource("shl_bld1",
            path: "assets/kms/us/shl_bld1.kms,us/stage/XXXX/cache/00266f8f.kms,cache/00266f8f.kms\r\r\n",
            cmdl: "assets/kms/us/shl_bld1.cmdl,us/stage/XXXX/cache/00266f8f.cmdl,eu/stage/XXXX/cache/00266f8f.cmdl\r\r\n");
        public static KmsResource ShlAcr = new KmsResource("shl_acr",
            path: "assets/kms/us/shl_acr.kms,us/stage/XXXX/cache/00f12e68.kms,cache/00f12e68.kms\r\r\n",
            cmdl: "assets/kms/us/shl_acr.cmdl,us/stage/XXXX/cache/00f12e68.cmdl,eu/stage/XXXX/cache/00f12e68.cmdl\r\r\n");
        public static KmsResource Shl = new KmsResource("shl",
            path: "assets/kms/us/shl.kms,us/stage/XXXX/cache/0001d96c.kms,cache/0001d96c.kms\r\r\n",
            cmdl: "assets/kms/us/shl.cmdl,us/stage/XXXX/cache/0001d96c.cmdl,eu/stage/XXXX/cache/0001d96c.cmdl\r\r\n");
        public static BasicResource SpecialGuardMar = new BasicResource("gbsstage_stage_a02a", 
            "assets/mar/us/gbsstage_stage_a02a.mar,us/stage/XXXX/cache/006ee2b2.mar,cache/006ee2b2.mar\r\r\n");
        public static BasicResource SpecialGuardSar = new BasicResource("gbs_w02a",
            "assets/sar/us/gbs_w02a.sar,us/stage/XXXX/cache/002fa38d.sar,cache/002fa38d.sar\r\r\n");
        public static BasicResource ShlBul1Texture = new BasicResource("shl_bul1_add",
            "textures/flatlist/shl_bul1_add.bmp.ctxr,stage/XXXX/cache/shl_bul1_add.bmp.ctxr,eu/stage/XXXX/cache/00573de0/00237a2d.ctxr\r\r\n");
        public static BasicResource ShlBul2Texture = new BasicResource("shl_bul2_add",
            "textures/flatlist/shl_bul2_add.bmp.ctxr,stage/XXXX/cache/shl_bul2_add.bmp.ctxr,eu/stage/XXXX/cache/00573de0/00337a2d.ctxr\r\r\n");
        public static BasicResource ShlBul3Texture = new BasicResource("shl_bul3_add",
            "textures/flatlist/shl_bul3_add.bmp.ctxr,stage/XXXX/cache/shl_bul3_add.bmp.ctxr,eu/stage/XXXX/cache/00573de0/00437a2d.ctxr\r\r\n");
        public static BasicResource ShlBul4Texture = new BasicResource("shl_bul4_add",
            "textures/flatlist/shl_bul4_add.bmp.ctxr,stage/XXXX/cache/shl_bul4_add.bmp.ctxr,eu/stage/XXXX/cache/00573de0/00537a2d.ctxr\r\r\n");
        public static BasicResource ShlBul5Texture = new BasicResource("shl_bul5_add",
            "textures/flatlist/shl_bul5_add.bmp.ctxr,stage/XXXX/cache/shl_bul5_add.bmp.ctxr,eu/stage/XXXX/cache/00573de0/00637a2d.ctxr\r\r\n");
        public static BasicResource ShlBul6Texture = new BasicResource("shl_bul6_add",
            "textures/flatlist/shl_bul6_add.bmp.ctxr,stage/XXXX/cache/shl_bul6_add.bmp.ctxr,eu/stage/XXXX/cache/00573de0/00737a2d.ctxr\r\r\n");
        public static BasicResource ShlChi1Texture = new BasicResource("shl_chi1_sub",
            "textures/flatlist/shl_chi1_sub.bmp.ctxr,stage/XXXX/cache/shl_chi1_sub.bmp.ctxr,eu/stage/XXXX/cache/00573de0/0023c905.ctxr\r\r\n");
        public static BasicResource ShlChi2Texture = new BasicResource("shl_chi2_sub",
            "textures/flatlist/shl_chi2_sub.bmp.ctxr,stage/XXXX/cache/shl_chi2_sub.bmp.ctxr,eu/stage/XXXX/cache/00573de0/0033c905.ctxr\r\r\n");
        public static BasicResource ShlChi3Texture = new BasicResource("shl_chi3_sub",
            "textures/flatlist/shl_chi3_sub.bmp.ctxr,stage/XXXX/cache/shl_chi3_sub.bmp.ctxr,eu/stage/XXXX/cache/00573de0/0043c905.ctxr\r\r\n");
        public static BasicResource ShlChi4Texture = new BasicResource("shl_chi4_sub",
            "textures/flatlist/shl_chi4_sub.bmp.ctxr,stage/XXXX/cache/shl_chi4_sub.bmp.ctxr,eu/stage/XXXX/cache/00573de0/0053c905.ctxr\r\r\n");
        public static BasicResource ShlChi5Texture = new BasicResource("shl_chi5_sub",
            "textures/flatlist/shl_chi5_sub.bmp.ctxr,stage/XXXX/cache/shl_chi5_sub.bmp.ctxr,eu/stage/XXXX/cache/00573de0/0063c905.ctxr\r\r\n");
        public static BasicResource ShlF1Texture = new BasicResource("shl_f1_add",
            "textures/flatlist/shl_f1_add.bmp.ctxr,stage/XXXX/cache/shl_f1_add.bmp.ctxr,eu/stage/XXXX/cache/00573de0/000c8982.ctxr\r\r\n");
        public static BasicResource ShlF2Texture = new BasicResource("shl_f2_add",
            "textures/flatlist/shl_f2_add.bmp.ctxr,stage/XXXX/cache/shl_f2_add.bmp.ctxr,eu/stage/XXXX/cache/00573de0/001c8982.ctxr\r\r\n");
        public static BasicResource ShlF3Texture = new BasicResource("shl_f3_add",
            "textures/flatlist/shl_f3_add.bmp.ctxr,stage/XXXX/cache/shl_f3_add.bmp.ctxr,eu/stage/XXXX/cache/00573de0/002c8982.ctxr\r\r\n");
        public static BasicResource ShlFrgTexture = new BasicResource("shl_frg_add_ovl",
            "textures/flatlist/shl_frg_add_ovl.bmp.ctxr,stage/XXXX/cache/shl_frg_add_ovl.bmp.ctxr,eu/stage/XXXX/cache/00349b50/00b24d7e.ctxr\r\r\n");
        public static BasicResource ShlLitWireTexture = new BasicResource("shl_lit_wire",
            "textures/flatlist/shl_lit_wire.bmp.ctxr,stage/XXXX/cache/shl_lit_wire.bmp.ctxr,eu/stage/XXXX/cache/009e05c5/000fe901.ctxr\r\r\n");
        public static BasicResource ShlLit1BTexture = new BasicResource("shl_lit1_b",
            "textures/flatlist/shl_lit1_b.bmp.ctxr,stage/XXXX/cache/shl_lit1_b.bmp.ctxr,eu/stage/XXXX/cache/009e05c5/009648ef.ctxr\r\r\n");
        public static BasicResource ShlLit1FTexture = new BasicResource("shl_lit1_f",
            "textures/flatlist/shl_lit1_f.bmp.ctxr,stage/XXXX/cache/shl_lit1_f.bmp.ctxr,eu/stage/XXXX/cache/009e05c5/009648f3.ctxr\r\r\n");
        public static BasicResource ShlLit1FMskDecalTexture = new BasicResource("shl_lit1_f_msk_decal",
            "textures/flatlist/shl_lit1_f_msk_decal.bmp.ctxr,stage/XXXX/cache/shl_lit1_f_msk_decal.bmp.ctxr,eu/stage/XXXX/cache/009e05c5/001defeb.ctxr\r\r\n");
        public static BasicResource ShlLit1F2Texture = new BasicResource("shl_lit1_f2",
            "textures/flatlist/shl_lit1_f2.bmp.ctxr,stage/XXXX/cache/shl_lit1_f2.bmp.ctxr,eu/stage/XXXX/cache/009e05c5/00c91ea4.ctxr\r\r\n");
        public static BasicResource ShlSAlpTexture = new BasicResource("shl_s_alp",
            "textures/flatlist/shl_s_alp.bmp.ctxr,stage/XXXX/cache/shl_s_alp.bmp.ctxr,eu/stage/XXXX/cache/00573de0/00d76db5.ctxr\r\r\n");
        public static BasicResource ComdlCacheStageA02a = new BasicResource("comdlcache_stage_a02a",
            "assets/tri/us/comdlcache_stage_a02a.tri,us/stage/XXXX/cache/00349b50.tri,cache/00349b50.tri\r\r\n");

        //Shotgun guard assets
        public static KmsResource SpsStageA12b = new KmsResource("sps_stage_a12b",
            path: "assets/kms/us/sps_stage_a12b.kms,us/stage/XXXX/cache/0001da73.kms,cache/0001da73.kms\r\r\n",
            cmdl: "assets/kms/us/sps_stage_a12b.cmdl,us/stage/XXXX/cache/0001da73.cmdl,eu/stage/XXXX/cache/0001da73.cmdl\r\r\n");
        public static KmsResource SpsEmbStageA12b = new KmsResource("sps_emb_stage_a12b",
            path: "assets/kms/us/sps_emb_stage_a12b.kms,us/stage/XXXX/cache/00613fa9.kms,cache/00613fa9.kms\r\r\n",
            cmdl: "assets/kms/us/sps_emb_stage_a12b.cmdl,us/stage/XXXX/cache/00613fa9.cmdl,eu/stage/XXXX/cache/00613fa9.cmdl\r\r\n");
        public static KmsResource SpsAmoStageA12b = new KmsResource("sps_amo_stage_a12b",
            path: "assets/kms/us/sps_amo_stage_a12b.kms,us/stage/XXXX/cache/00612fb6.kms,cache/00612fb6.kms\r\r\n",
            cmdl: "assets/kms/us/sps_amo_stage_a12b.cmdl,us/stage/XXXX/cache/00612fb6.cmdl,eu/stage/XXXX/cache/00612fb6.cmdl\r\r\n");
        public static BasicResource SpsAll2MskTexture = new BasicResource("sps_all2_msk",
            "textures/flatlist/sps_all2_msk.bmp.ctxr,stage/XXXX/cache/sps_all2_msk.bmp.ctxr,eu/stage/XXXX/cache/009e05c5/0013a1f5.ctxr\r\r\n");
        public static BasicResource SpsEmbTexture = new BasicResource("sps_emb.bmp",
            "textures/flatlist/sps_emb.bmp.ctxr,stage/XXXX/cache/sps_emb.bmp.ctxr,eu/stage/XXXX/cache/009e05c5/00613fa9.ctxr\r\r\n");
        //TODO: do we need to include a specific transcache.tri or the gbss.tri?
    }
    
    public class BasicResource
    {
        public string Name { get; set; }
        public string Path { get; set; }
        
        public BasicResource(string name, string path)
        {
            Name = name;
            Path = path;
        }
    }
    
    public class CtxrResource : BasicResource
    {
        public string Tri { get; set; }
        public CtxrResource(string name, string path, string tri) : base(name, path)
        {
            Name = name;
            Path = path;
            Tri = tri;
        }
    }
    
    public class KmsResource : BasicResource
    {
        public string Cmdl { get; set; }
        
        public KmsResource(string name, string path, string cmdl) : base(name, path)
        {
            Name = name;
            Cmdl = cmdl;
            Path = path;
        }
    }

    public class Resource
    {
        public static List<BasicResource> ResourceList = new List<BasicResource>
        {
            MGS2Resource.ColdMedsLabel, MGS2Resource.ThermalGogglesLabel, MGS2Resource.GoggleIbox, MGS2Resource.GoggleSh, MGS2Resource.AKAmmoLabel,
            MGS2Resource.AKWeaponLabel, MGS2Resource.MagazineIbox, MGS2Resource.MagazineLabel, MGS2Resource.MagazineSh, MGS2Resource.C4Label,
            MGS2Resource.ClaymoreLabel, MGS2Resource.DmicLabel, MGS2Resource.GrenadeLabel, MGS2Resource.M4AmmoLabel, MGS2Resource.M4WeaponLabel,
            MGS2Resource.NikitaAmmoLabel, MGS2Resource.NikitaWeaponLabel, MGS2Resource.PSG1AmmoLabel, MGS2Resource.PSG1WeaponLabel, MGS2Resource.PSG1TAmmoLabel,
            MGS2Resource.PSG1TWeaponLabel, MGS2Resource.RGB6AmmoLabel, MGS2Resource.RGB6WeaponLabel, MGS2Resource.BodyArmorLabel, MGS2Resource.DigitalCameraIbox,
            MGS2Resource.DigitalCameraLabel, MGS2Resource.DigitalCameraSh, MGS2Resource.StingerAmmoLabel, MGS2Resource.StingerWeaponLabel, MGS2Resource.AKSuppressorLabel,
            MGS2Resource.PentazeminLabel, MGS2Resource.SensorBLabel, MGS2Resource.SocomSuppressorLabel, MGS2Resource.MineDetectorLabel, MGS2Resource.NVGLabel,
            MGS2Resource.RifleAmmoIbox, MGS2Resource.RifleAmmoSh, MGS2Resource.RifleIbox, MGS2Resource.RifleSh, MGS2Resource.LauncherAmmoIbox,
            MGS2Resource.LauncherAmmoSh, MGS2Resource.LauncherIbox, MGS2Resource.LauncherSh, MGS2Resource.Box2Ibox, MGS2Resource.Box2Sh,
            MGS2Resource.CbxLabel, MGS2Resource.DetectorIbox, MGS2Resource.DetectorSh, MGS2Resource.DmicIbox, MGS2Resource.DmicSh,
            MGS2Resource.RationIbox, MGS2Resource.M9AmmoLabel, MGS2Resource.M9WeaponLabel, MGS2Resource.StunLabel, MGS2Resource.BandageLabel,
            MGS2Resource.ShaverLabel, MGS2Resource.MedicineIbox, MGS2Resource.MedicineSh, MGS2Resource.HandgunIbox, MGS2Resource.HandgunSh,
            MGS2Resource.ChaffLabel, MGS2Resource.SocomAmmoLabel, MGS2Resource.GrenadeIbox, MGS2Resource.GrenadeSh, MGS2Resource.HandgunAmmoIbox,
            MGS2Resource.HandgunAmmoSh, MGS2Resource.RationSh, MGS2Resource.RationLabel, MGS2Resource.CoolantSprayLabel, MGS2Resource.SocomLabel,
            MGS2Resource.UspLabel, MGS2Resource.ScopeCustomBox, MGS2Resource.ItemBox, MGS2Resource.CigarettesIbox, MGS2Resource.CigarettesIboxSh,
            MGS2Resource.CigarettesLabel, MGS2Resource.SensorALabel, MGS2Resource.APSensorIbox, MGS2Resource.APSensorLabel, MGS2Resource.ItemBox2,
            MGS2Resource.ColdMedsLabelTexture, MGS2Resource.GoggleIboxTexture, MGS2Resource.GoggleIboxTri, MGS2Resource.DigitalCameraBoxTexture, MGS2Resource.Dzp2TxAlpTexture,
            MGS2Resource.RifleIboxTexture, MGS2Resource.LauncherAmmoSideTexture, MGS2Resource.LauncherIboxTexture, MGS2Resource.Ibox2TxAllTexture, MGS2Resource. DMicLabelTexture,
            MGS2Resource.RationTexture, MGS2Resource.MedicineBoxTexture, MGS2Resource.ShlLit2, MGS2Resource.ShlLit1, MGS2Resource.ShlFrg1,
            MGS2Resource.ShlChi5, MGS2Resource.ShlChi4, MGS2Resource.ShlChi3, MGS2Resource.ShlChi2, MGS2Resource.ShlChi1,
            MGS2Resource.ShlBul6, MGS2Resource.ShlBul5, MGS2Resource.ShlBul4, MGS2Resource.ShlBul3, MGS2Resource.ShlBul2,
            MGS2Resource.ShlBul1, MGS2Resource.ShlBlu3, MGS2Resource.ShlBlu2, MGS2Resource.ShlBlu1, MGS2Resource.ShlBlr3,
            MGS2Resource.ShlBlr2, MGS2Resource.ShlBlr1, MGS2Resource.ShlBll3, MGS2Resource.ShlBll2, MGS2Resource.ShlBll1,
            MGS2Resource.ShlBld3, MGS2Resource.ShlBld2, MGS2Resource.ShlBld1, MGS2Resource.ShlAcr, MGS2Resource.Shl,
            MGS2Resource.SpecialGuardMar, MGS2Resource.SpecialGuardSar, MGS2Resource.ShlBul1Texture, MGS2Resource.ShlBul2Texture, MGS2Resource.ShlBul3Texture,
            MGS2Resource.ShlBul4Texture, MGS2Resource.ShlBul5Texture, MGS2Resource.ShlBul6Texture, MGS2Resource.ShlChi1Texture, MGS2Resource.ShlChi2Texture,
            MGS2Resource.ShlChi3Texture, MGS2Resource.ShlChi4Texture, MGS2Resource.ShlChi5Texture, MGS2Resource.ShlF1Texture, MGS2Resource.ShlF2Texture,
            MGS2Resource.ShlF3Texture, MGS2Resource.ShlFrgTexture, MGS2Resource.ShlLitWireTexture, MGS2Resource.ShlLit1BTexture, MGS2Resource.ShlLit1FTexture,
            MGS2Resource.ShlLit1FMskDecalTexture, MGS2Resource.ShlLit1F2Texture, MGS2Resource.ShlSAlpTexture, MGS2Resource.ComdlCacheStageA02a, MGS2Resource.SpsStageA12b,
            MGS2Resource.SpsEmbStageA12b, MGS2Resource.SpsAmoStageA12b, MGS2Resource.SpsAll2MskTexture, MGS2Resource.SpsEmbTexture
            /*MGS2Resource.RifleAmmoIbox1, MGS2Resource.RifleAmmoIbox2, MGS2Resource.RilfeIbox, //these three change nothing sadge /*MGS2Resource.IboxAmoNkt //Unused resource*/
        };

        public static List<string> AllPlantWeaponItemResources = new List<string>()
        {
            "akammolabel", "akweaponlabel", "magazineibox", "magazinelabel", "magazinessh", "c4label", "chafflabel",
            "claymorelabel", "dmiclabel", "grenadelabel", "m4ammolabel", "m4weaponlabel", "m9ammolabel", "m9weaponlabel",
            "nikitaammolabel", "nikitaweaponlabel", "psg1ammolabel", "psg1weaponlabel", "psg1tammolabel", "psg1tweaponlabel", "rgb6ammolabel",
            "rgb6weaponlabel", "socomammolabel", "stingerammolabel", "stingerweaponlabel", "stunlabel", "aksuppressorlabel",
            "bandageslabel", "bodyarmorlabel", "rationibox", "rationsh", "rationlabel", "coldmedslabel", "digitalcamerabox",
            "digitalcameralabel", "digitalcamerash", "pentazeminlabel", "sensorblabel", "shaverlabel", "socomsuppressorlabel", "thermalgoggleslabel",
            "minedetectorlabel", "nvglabel", "rifleammoibox", "rifleammosh", "rifleibox", "riflesh",
            "launcherammoibox", "launcherammosh", "launcheribox", "launchersh", "grenadeibox", "grenadesh", "handgunammoibox",
            "handgunammosh", "medicineibox", "medicinesh", "handgunibox", "handgunsh", "box2ibox", "box2sh",
            "goggleibox", "gogglesh", "cboxlabel", "detectoribox", "detectorsh", "dmicibox", "dmicsh", "clslabel", "scmlabel", "itembox"
        };

        public static List<string> AllTankerWeaponItemResources = new List<string>()
        {
            "chafflabel", "grenadelabel", "m9ammolabel", "stunlabel", "uspammolabel", "bandageslabel",
            "rationibox", "rationsh", "rationlabel", "coldmedslabel", "pentazeminlabel", "thermalgoggleslabel", "uspsuppressorlabel", "grenadeibox",
            "grenadesh", "handgunammoibox", "handgunammosh", "medicineibox", "medicinesh", "box2ibox", "box2sh", "goggleibox", "gogglesh", "cboxlabel",
            "usplabel"
        };

        public string CommonName { get; set; }
        public string Kms { get; set; }
        public string Cmdl { get; set; }
        public string Ctxr { get; set; }
        public string Tri { get; set; }

        public Resource(string name, string kms, string cmdl, string ctxr, string tri)
        {
            CommonName = name;
            Kms = kms;
            Cmdl = cmdl;
            Ctxr = ctxr;
            Tri = tri;
        }

        public static BasicResource LookupResource(string name)
        {
            return ResourceList.Find(x => x.Name == name.ToLower());
        }
    }
}
