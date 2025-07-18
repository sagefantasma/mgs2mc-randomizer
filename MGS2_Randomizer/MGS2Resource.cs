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
        public static BasicResource SpecialGuardMar1 = new BasicResource("gbsstage_stage_a02a", 
            "assets/mar/us/gbsstage_stage_a02a.mar,us/stage/XXXX/cache/006ee2b2.mar,cache/006ee2b2.mar\r\r\n", true);
        /*public static BasicResource SpecialGuardSar1 = new BasicResource("gbsstage_stage_a02a",
            "assets/mar/us/gbsstage_stage_a02a.sar,us/stage/XXXX/cache/006ee2b2.mar,cache/006ee2b2.mar\r\r\n");*/
        public static BasicResource SpecialGuardMar2 = new BasicResource("gbs_stage_a02a.mar",
            "assets/mar/us/gbs_stage_a02a.mar,us/stage/XXXX/cache/0001a8b3.mar,cache/0001a8b3.mar\r\r\n", true);
        public static BasicResource SpecialGuardSar2 = new BasicResource("gbs_stage_a02a.sar",
            "assets/sar/us/gbs_stage_a02a.sar,us/stage/XXXX/cache/0001a8b3.sar,cache/0001a8b3.sar\r\r\n");
        public static BasicResource SpecialGuardTransCacheTri = new BasicResource("transcache_stage_a24a",
            "assets/tri/us/transcache_stage_a24a.tri,us/stage/XXXX/cache/00573de0.tri,cache/00573de0.tri\r\r\n");
        public static BasicResource SpecialGuardSar3 = new BasicResource("gbs_w02a",
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
        public static BasicResource ComdlCacheStageA02aTri = new BasicResource("comdlcache_stage_a02a",
            "assets/tri/us/comdlcache_stage_w25a.tri,us/stage/XXXX/cache/00349b50.tri,cache/00349b50.tri\r\r\n");

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
        public static BasicResource ShotgunGuardTri = new BasicResource("gbs_gba_def_nm_stage_a24a",
            "assets/tri/us/gbs_gba_def_nm_stage_a24d.tri,us/stage/XXXX/cache/009e05c5.tri,cache/009e05c5.tri\r\r\n");

        //Hi-tech guard assets
        //There are probably more resources here than are really required, but I don't know for certain. This seems to work as is, so I'm happy with that.
        public static BasicResource HtcArmUc0033ac05 = new BasicResource("htc_arm_uc_0033ac05",
            "textures/flatlist/htc_arm_uc.bmp.ctxr,stage/XXXX/cache/htc_arm_uc.bmp.ctxr,eu/stage/XXXX/cache/0033ac05/00cf3b99.ctxr\r\r\n");
        public static BasicResource HtcArmUc00fbbaaf = new BasicResource("htc_arm_uc_00fbbaaf",
            "textures/flatlist/htc_arm_uc.bmp.ctxr,stage/XXXX/cache/htc_arm_uc.bmp.ctxr,eu/stage/XXXX/cache/00fbbaaf/00cf3b99.ctxr\r\r\n");
        public static BasicResource HtcBeltN2 = new BasicResource("htc_belt_n2",
            "textures/flatlist/htc_belt_n2.bmp.ctxr,stage/XXXX/cache/htc_belt_n2.bmp.ctxr,eu/stage/XXXX/cache/00fbbaaf/00e19cf1.ctxr\r\r\n");
        public static BasicResource HtcBeltUc = new BasicResource("htc_belt_uc",
            "textures/flatlist/htc_belt_uc.bmp.ctxr,stage/XXXX/cache/htc_belt_uc.bmp.ctxr,eu/stage/XXXX/cache/00fbbaaf/00e19e02.ctxr\r\r\n");
        public static BasicResource HtcBloodAlpOvl = new BasicResource("htc_blood_alp_ovl",
            "textures/flatlist/htc_blood_alp_ovl.bmp.ctxr,stage/XXXX/cache/htc_blood_alp_ovl.bmp.ctxr,eu/stage/XXXX/cache/009e05c5/00fd1fce.ctxr\r\r\n");
        public static BasicResource HtcBodyBUc = new BasicResource("htc_body_b_uc",
            "textures/flatlist/htc_body_b_uc.bmp.ctxr,stage/XXXX/cache/htc_body_b_uc.bmp.ctxr,eu/stage/XXXX/cache/00fbbaaf/006ed893.ctxr\r\r\n");
        public static BasicResource HtcBodyUc = new BasicResource("htc_body_uc",
            "textures/flatlist/htc_body_uc.bmp.ctxr,stage/XXXX/cache/htc_body_uc.bmp.ctxr,eu/stage/XXXX/cache/00fbbaaf/00641e16.ctxr\r\r\n");
        public static BasicResource HtcEye2OvlHlf = new BasicResource("htc_eye2_ovl_hlf",
            "textures/flatlist/htc_eye2_ovl_hlf.bmp.ctxr,stage/XXXX/cache/htc_eye2_ovl_hlf.bmp.ctxr,eu/stage/XXXX/cache/00fbbaaf/00926a67.ctxr\r\r\n");
        public static BasicResource HtcEye2OvlSubAlp = new BasicResource("htc_eye2_ovl_sub_alp",
            "textures/flatlist/htc_eye2_ovl_sub_alp.bmp.ctxr,stage/XXXX/cache/htc_eye2_ovl_sub_alp.bmp.ctxr,eu/stage/XXXX/cache/00fbbaaf/006a3b68.ctxr\r\r\n");
        public static BasicResource HtcFaceUc = new BasicResource("htc_face_uc",
            "textures/flatlist/htc_face_uc.bmp.ctxr,stage/XXXX/cache/htc_face_uc.bmp.ctxr,eu/stage/XXXX/cache/00fbbaaf/004a1efa.ctxr\r\r\n");
        public static BasicResource HtcGunFro = new BasicResource("htc_gun_fro",
            "textures/flatlist/htc_gun_fro.bmp.ctxr,stage/XXXX/cache/htc_gun_fro.bmp.ctxr,eu/stage/XXXX/cache/00fbbaaf/00f73b0e.ctxr\r\r\n");
        public static BasicResource HtcGunSide = new BasicResource("htc_gun_side",
            "textures/flatlist/htc_gun_side.bmp.ctxr,stage/XXXX/cache/htc_gun_side.bmp.ctxr,eu/stage/XXXX/cache/00fbbaaf/00edbce3.ctxr\r\r\n");
        public static BasicResource HtcGunTop = new BasicResource("htc_gun_top",
            "textures/flatlist/htc_gun_top.bmp.ctxr,stage/XXXX/cache/htc_gun_top.bmp.ctxr,eu/stage/XXXX/cache/00fbbaaf/00f772af.ctxr\r\r\n");
        public static BasicResource HtcHandIUc0033ac05 = new BasicResource("htc_hand_i_uc_0033ac05",
            "textures/flatlist/htc_hand_i_uc.bmp.ctxr,stage/XXXX/cache/htc_hand_i_uc.bmp.ctxr,eu/stage/XXXX/cache/0033ac05/0077eae9.ctxr\r\r\n");
        public static BasicResource HtcHandIUc00fbbaaf = new BasicResource("htc_hand_i_uc_00fbbaaf",
            "textures/flatlist/htc_hand_i_uc.bmp.ctxr,stage/XXXX/cache/htc_hand_i_uc.bmp.ctxr,eu/stage/XXXX/cache/00fbbaaf/0077eae9.ctxr\r\r\n");
        public static BasicResource HtcHandOUc0033ac05 = new BasicResource("htc_hand_o_uc_0033ac05",
            "textures/flatlist/htc_hand_o_uc.bmp.ctxr,stage/XXXX/cache/htc_hand_o_uc.bmp.ctxr,eu/stage/XXXX/cache/0033ac05/007aeae9.ctxr\r\r\n");
        public static BasicResource HtcHandOUc00fbbaaf = new BasicResource("htc_hand_o_uc_00fbbaaf",
            "textures/flatlist/htc_hand_o_uc.bmp.ctxr,stage/XXXX/cache/htc_hand_o_uc.bmp.ctxr,eu/stage/XXXX/cache/00fbbaaf/007aeae9.ctxr\r\r\n");
        public static BasicResource HtcHelmetBUc = new BasicResource("htc_helmet_b_uc",
            "textures/flatlist/htc_helmet_b_uc.bmp.ctxr,stage/XXXX/cache/htc_helmet_b_uc.bmp.ctxr,eu/stage/XXXX/cache/00fbbaaf/00206e79.ctxr\r\r\n");
        public static BasicResource HtcHelmetBUcOvlAlpSub = new BasicResource("htc_helmet_b_uc_ovl_alp_sub",
            "textures/flatlist/htc_helmet_b_uc_ovl_alp_sub.bmp.ctxr,stage/XXXX/cache/htc_helmet_b_uc_ovl_alp_sub.bmp.ctxr,eu/stage/XXXX/cache/00fbbaaf/00482f73.ctxr\r\r\n");
        public static BasicResource HtcHelmetIUc = new BasicResource("htc_helmet_i_uc",
            "textures/flatlist/htc_helmet_i_uc.bmp.ctxr,stage/XXXX/cache/htc_helmet_i_uc.bmp.ctxr,eu/stage/XXXX/cache/00fbbaaf/0023ee79.ctxr\r\r\n");
        public static BasicResource HtcHelmetUc = new BasicResource("htc_helmet_uc",
            "textures/flatlist/htc_helmet_uc.bmp.ctxr,stage/XXXX/cache/htc_helmet_uc.bmp.ctxr,eu/stage/XXXX/cache/00fbbaaf/00dd8a7b.ctxr\r\r\n");
        public static BasicResource HtcHelmetUcOvlAlpSub = new BasicResource("htc_helmet_uc_ovl_alp_sub",
            "textures/flatlist/htc_helmet_uc_ovl_alp_sub.bmp.ctxr,stage/XXXX/cache/htc_helmet_uc_ovl_alp_sub.bmp.ctxr,eu/stage/XXXX/cache/00fbbaaf/00085b45.ctxr\r\r\n");
        public static BasicResource HtcLegUc = new BasicResource("htc_leg_uc",
            "textures/flatlist/htc_leg_uc.bmp.ctxr,stage/XXXX/cache/htc_leg_uc.bmp.ctxr,eu/stage/XXXX/cache/00fbbaaf/00fc3bae.ctxr\r\r\n");
        public static BasicResource HtcLightUc = new BasicResource("htc_light_uc",
            "textures/flatlist/htc_light_uc.bmp.ctxr,stage/XXXX/cache/htc_light_uc.bmp.ctxr,eu/stage/XXXX/cache/00fbbaaf/007e3bf4.ctxr\r\r\n");
        public static BasicResource HtcLightUcOvlSubAlp = new BasicResource("htc_light_uc_ovl_sub_alp",
            "textures/flatlist/htc_light_uc_ovl_sub_alp.bmp.ctxr,stage/XXXX/cache/htc_light_uc_ovl_sub_alp.bmp.ctxr,eu/stage/XXXX/cache/00fbbaaf/003fa0cf.ctxr\r\r\n");
        public static BasicResource HtcNeckIUc = new BasicResource("htc_neck_i_uc",
            "textures/flatlist/htc_neck_i_uc.bmp.ctxr,stage/XXXX/cache/htc_neck_i_uc.bmp.ctxr,eu/stage/XXXX/cache/00fbbaaf/007e0837.ctxr\r\r\n");
        public static BasicResource HtcNeckOUc = new BasicResource("htc_neck_o_uc",
            "textures/flatlist/htc_neck_o_uc.bmp.ctxr,stage/XXXX/cache/htc_neck_o_uc.bmp.ctxr,eu/stage/XXXX/cache/00fbbaaf/00810837.ctxr\r\r\n");
        public static BasicResource HtcPorchUc = new BasicResource("htc_porch_uc",
            "textures/flatlist/htc_porch_uc.bmp.ctxr,stage/XXXX/cache/htc_porch_uc.bmp.ctxr,eu/stage/XXXX/cache/00fbbaaf/00285d8a.ctxr\r\r\n");
        public static BasicResource HtcShoesUc = new BasicResource("htc_shoes_uc",
            "textures/flatlist/htc_shoes_uc.bmp.ctxr,stage/XXXX/cache/htc_shoes_uc.bmp.ctxr,eu/stage/XXXX/cache/00fbbaaf/004df3c4.ctxr\r\r\n");
        public static BasicResource HtcShoulderUc = new BasicResource("htc_shoulder_uc",
            "textures/flatlist/htc_shoulder_uc.bmp.ctxr,stage/XXXX/cache/htc_shoulder_uc.bmp.ctxr,eu/stage/XXXX/cache/00fbbaaf/00ebb045.ctxr\r\r\n");
        public static BasicResource HtcShoulderUcOvlSubAlp = new BasicResource("htc_shoulder_uc_ovl_sub_alp",
            "textures/flatlist/htc_shoulder_uc_ovl_sub_alp.bmp.ctxr,stage/XXXX/cache/htc_shoulder_uc_ovl_sub_alp.bmp.ctxr,eu/stage/XXXX/cache/00fbbaaf/0084b7a6.ctxr\r\r\n");
        public static BasicResource HtcUcOvlMod1120AlpEmap = new BasicResource("htc_uc_ovl_mod1120_alp_emap",
            "textures/flatlist/htc_uc_ovl_mod1120_alp_emap.bmp.ctxr,stage/XXXX/cache/htc_uc_ovl_mod1120_alp_emap.bmp.ctxr,eu/stage/XXXX/cache/00fbbaaf/008f2b58.ctxr\r\r\n");
        public static BasicResource HtcUnderPadUc = new BasicResource("htc_under_pad_uc",
            "textures/flatlist/htc_under_pad_uc.bmp.ctxr,stage/XXXX/cache/htc_under_pad_uc.bmp.ctxr,eu/stage/XXXX/cache/00fbbaaf/00f8634b.ctxr\r\r\n");
        public static BasicResource HtcdtOvlMod1120AlpEmap = new BasicResource("htcdt_ovl_mod1120_alp_emap",
            "textures/flatlist/htcdt_ovl_mod1120_alp_emap.bmp.ctxr,stage/XXXX/cache/htcdt_ovl_mod1120_alp_emap.bmp.ctxr,eu/stage/XXXX/cache/00fbbaaf/00a96be9.ctxr\r\r\n");
        public static BasicResource SnaM9Glip = new BasicResource("sna_m9_glip",
            "textures/flatlist/sna_m9_glip.bmp.ctxr,stage/XXXX/cache/sna_m9_glip.bmp.ctxr,eu/stage/XXXX/cache/00fbbaaf/000b52f7.ctxr\r\r\n");
        public static KmsResource HtcBloodFace = new KmsResource("htc_blood_face",
            path: "assets/kms/us/htc_blood_face.kms,us/stage/XXXX/cache/00ab985c.kms,cache/00ab985c.kms\r\r\n",
            cmdl: "assets/kms/us/htc_blood_face.cmdl,us/stage/XXXX/cache/00ab985c.cmdl,eu/stage/XXXX/cache/00ab985c.cmdl\r\r\n");
        public static KmsResource HtcDefMt = new KmsResource("htc_def_mt",
            path: "assets/kms/us/htc_def_mt.kms,us/stage/XXXX/cache/00fbbaaf.kms,cache/00fbbaaf.kms\r\r\n",
            cmdl: "assets/kms/us/htc_def_mt.cmdl,us/stage/XXXX/cache/00fbbaaf.cmdl,eu/stage/XXXX/cache/00fbbaaf.cmdl\r\r\n");
        public static KmsResource HtcHandDef = new KmsResource("htc_hand_def",
            path: "assets/kms/us/htc_hand_def.kms,us/stage/XXXX/cache/0033ac05.kms,cache/0033ac05.kms\r\r\n",
            cmdl: "assets/kms/us/htc_hand_def.cmdl,us/stage/XXXX/cache/0033ac05.cmdl,eu/stage/XXXX/cache/0033ac05.cmdl\r\r\n");
        public static KmsResource M4GrnHtc = new KmsResource("m4_grn_htc",
            path: "assets/kms/us/m4_grn_htc.kms,us/stage/XXXX/cache/00e8419b.kms,cache/00e8419b.kms\r\r\n",
            cmdl: "assets/kms/us/m4_grn_htc.cmdl,us/stage/XXXX/cache/00e8419b.cmdl,eu/stage/XXXX/cache/00e8419b.cmdl\r\r\n");
        public static KmsResource M4aGrnAmoHtc = new KmsResource("m4a_grn_amo_htc",
            path: "assets/kms/us/m4a_grn_amo_htc.kms,us/stage/XXXX/cache/0080814a.kms,cache/0080814a.kms\r\r\n",
            cmdl: "assets/kms/us/m4a_grn_amo_htc.cmdl,us/stage/XXXX/cache/0080814a.cmdl,eu/stage/XXXX/cache/0080814a.cmdl\r\r\n");
        public static BasicResource HtcHandDefTri = new BasicResource("htc_hand_def.tri",
            "assets/tri/us/htc_hand_def.tri,us/stage/XXXX/cache/0033ac05.tri,cache/0033ac05.tri\r\r\n");
        public static BasicResource HtcDefMtTri = new BasicResource("htc_def_mt.tri",
            "assets/tri/us/htc_def_mt.tri,us/stage/XXXX/cache/00fbbaaf.tri,cache/00fbbaaf.tri\r\r\n");
        public static BasicResource HtcHandDefCv2 = new BasicResource("htc_hand_def.cv2",
            "assets/cv2/us/htc_hand_def.cv2,us/stage/XXXX/cache/0033ac05.cv2,cache/0033ac05.cv2\r\r\n");
        public static BasicResource HtcHand5 = new BasicResource("htc_hand_5",
            "assets/cv2/us/htc_hand_5.cv2,us/stage/XXXX/cache/00bfccb8.cv2,cache/00bfccb8.cv2\r\r\n");
        public static BasicResource HtcHand4 = new BasicResource("htc_hand_4",
            "assets/cv2/us/htc_hand_4.cv2,us/stage/XXXX/cache/00bfccb7.cv2,cache/00bfccb7.cv2\r\r\n");
        public static BasicResource HtcHand3 = new BasicResource("htc_hand_3",
            "assets/cv2/us/htc_hand_3.cv2,us/stage/XXXX/cache/00bfccb6.cv2,cache/00bfccb6.cv2\r\r\n");
        public static BasicResource HtcHand2 = new BasicResource("htc_hand_2",
            "assets/cv2/us/htc_hand_2.cv2,us/stage/XXXX/cache/00bfccb5.cv2,cache/00bfccb5.cv2\r\r\n");
        public static BasicResource HtcHand1 = new BasicResource("htc_hand_1",
            "assets/cv2/us/htc_hand_1.cv2,us/stage/XXXX/cache/00bfccb4.cv2,cache/00bfccb4.cv2\r\r\n");
        public static BasicResource HtcDefMtCv2 = new BasicResource("htc_def_mt.cv2",
            "assets/cv2/us/htc_def_mt.cv2,us/stage/XXXX/cache/00fbbaaf.cv2,cache/00fbbaaf.cv2\r\r\n");
        /*public static BasicResource HiTechGuardTri = new BasicResource("",
            "assets/tri/us/gbs_gba_def_nm_stage_a12b.tri,us/stage/XXXX/cache/009e05c5.tri,cache/009e05c5.tri\r\r\n");*/
        public static BasicResource M4Alp = new BasicResource("m4_alp",
            "textures/flatlist/m4_alp.bmp.ctxr,stage/XXXX/cache/m4_alp.bmp.ctxr,eu/stage/XXXX/cache/00573de0/007112cd.ctxr\r\r\n");
        public static BasicResource M4aAll = new BasicResource("m4a_all",
            "textures/flatlist/m4a_all.bmp.ctxr,stage/XXXX/cache/m4a_all.bmp.ctxr,eu/stage/XXXX/cache/009e05c5/00412d9a.ctxr\r\r\n");
        public static BasicResource M4aGlUnit = new BasicResource("m4a_gl_unit",
            "textures/flatlist/m4a_gl_unit.bmp.ctxr,stage/XXXX/cache/m4a_gl_unit.bmp.ctxr,eu/stage/XXXX/cache/009e05c5/001059ed.ctxr\r\r\n");
        public static BasicResource M4aSbS1 = new BasicResource("m4a_sb_s1",
            "textures/flatlist/m4a_sb_s1.bmp.ctxr,stage/XXXX/cache/m4a_sb_s1.bmp.ctxr,eu/stage/XXXX/cache/009e05c5/00d14396.ctxr\r\r\n");
        public static BasicResource M4grnBulHigh = new BasicResource("m4grn_bul_high",
            "textures/flatlist/m4grn_bul_high.bmp.ctxr,stage/XXXX/cache/m4grn_bul_high.bmp.ctxr,eu/stage/XXXX/cache/009e05c5/002554bd.ctxr\r\r\n");
        public static BasicResource M4GrnEmb = new BasicResource("m4grn_emb",
            "textures/flatlist/m4grn_emb.bmp.ctxr,stage/XXXX/cache/m4grn_emb.bmp.ctxr,eu/stage/XXXX/cache/009e05c5/007fdcad.ctxr\r\r\n");
        public static BasicResource M92Jyuukou = new BasicResource("m92_jyuukou",
            "textures/flatlist/m92_jyuukou.bmp.ctxr,stage/XXXX/cache/m92_jyuukou.bmp.ctxr,eu/stage/XXXX/cache/009e05c5/00e14f89.ctxr\r\r\n");
        public static BasicResource MkrvAll = new BasicResource("mkrv_all",
            "textures/flatlist/mkrv_all.bmp.ctxr,stage/XXXX/cache/mkrv_all.bmp.ctxr,eu/stage/XXXX/cache/009e05c5/00949597.ctxr\r\r\n");
        public static BasicResource RadMusen1002f5aa1 = new BasicResource("rad_musen1002f5aa1",
            "textures/flatlist/rad_musen1.bmp.ctxr,stage/XXXX/cache/rad_musen1.bmp.ctxr,eu/stage/XXXX/cache/009e05c5/002f5aa1.ctxr\r\r\n");
        public static BasicResource RadMusen100a142a1 = new BasicResource("rad_musen100a142a1",
            "textures/flatlist/rad_musen1.bmp.ctxr,stage/XXXX/cache/rad_musen1.bmp.ctxr,eu/stage/XXXX/cache/009e05c5/00a142a1.ctxr\r\r\n");
        public static BasicResource RadMusen2 = new BasicResource("rad_musen2",
            "textures/flatlist/rad_musen2.bmp.ctxr,stage/XXXX/cache/rad_musen2.bmp.ctxr,eu/stage/XXXX/cache/009e05c5/002f5aa2.ctxr\r\r\n");
        public static BasicResource RadMusen3 = new BasicResource("rad_musen3",
            "textures/flatlist/rad_musen3.bmp.ctxr,stage/XXXX/cache/rad_musen3.bmp.ctxr,eu/stage/XXXX/cache/009e05c5/002f5aa3.ctxr\r\r\n");
        public static BasicResource RadMusen4 = new BasicResource("rad_musen4",
            "textures/flatlist/rad_musen4.bmp.ctxr,stage/XXXX/cache/rad_musen4.bmp.ctxr,eu/stage/XXXX/cache/009e05c5/002f5aa4.ctxr\r\r\n");
        public static BasicResource RadMusen5 = new BasicResource("rad_musen5",
            "textures/flatlist/rad_musen5.bmp.ctxr,stage/XXXX/cache/rad_musen5.bmp.ctxr,eu/stage/XXXX/cache/009e05c5/002f5aa5.ctxr\r\r\n");
        public static BasicResource SelSling1AlpOvl = new BasicResource("sel_sling1_alp_ovl",
            "textures/flatlist/sel_sling1_alp_ovl.bmp.ctxr,stage/XXXX/cache/sel_sling1_alp_ovl.bmp.ctxr,eu/stage/XXXX/cache/009e05c5/00011b09.ctxr\r\r\n");
        public static BasicResource SelSling2AlpOvl = new BasicResource("sel_sling2_alp_ovl",
            "textures/flatlist/sel_sling2_alp_ovl.bmp.ctxr,stage/XXXX/cache/sel_sling2_alp_ovl.bmp.ctxr,eu/stage/XXXX/cache/009e05c5/00021b09.ctxr\r\r\n");
        public static BasicResource SelSling3 = new BasicResource("sel_sling3",
            "textures/flatlist/sel_sling3.bmp.ctxr,stage/XXXX/cache/sel_sling3.bmp.ctxr,eu/stage/XXXX/cache/00573de0/00bebdce.ctxr\r\r\n");
        public static BasicResource UspAll = new BasicResource("usp_all",
            "textures/flatlist/usp_all.bmp.ctxr,stage/XXXX/cache/usp_all.bmp.ctxr,eu/stage/XXXX/cache/009e05c5/00313019.ctxr\r\r\n");
        public static BasicResource UspEmb = new BasicResource("usp_emb",
            "textures/flatlist/usp_emb.bmp.ctxr,stage/XXXX/cache/usp_emb.bmp.ctxr,eu/stage/XXXX/cache/009e05c5/0031402f.ctxr\r\r\n");
        public static BasicResource Brack010101 = new BasicResource("brack_01_01_01",
            "textures/flatlist/brack_01_01_01.bmp.ctxr,stage/XXXX/cache/brack_01_01_01.bmp.ctxr,eu/stage/XXXX/cache/009e05c5/00a5e14c.ctxr\r\r\n");
        public static BasicResource DogtagChainBlackMsk = new BasicResource("dogtag_chain_black_msk",
            "textures/flatlist/dogtag_chain_black_msk.bmp.ctxr,stage/XXXX/cache/dogtag_chain_black_msk.bmp.ctxr,eu/stage/XXXX/cache/009e05c5/001a5b53.ctxr\r\r\n");
        public static BasicResource GradationAlpOvl = new BasicResource("gradation_alp_ovl",
            "textures/flatlist/gradation_alp_ovl.bmp.ctxr,stage/XXXX/cache/gradation_alp_ovl.bmp.ctxr,eu/stage/XXXX/cache/009e05c5/009112a6.ctxr\r\r\n");
        public static BasicResource GrsBlack = new BasicResource("grs_black",
            "textures/flatlist/grs_black.bmp.ctxr,stage/XXXX/cache/grs_black.bmp.ctxr,eu/stage/XXXX/cache/009e05c5/00c23e4f.ctxr\r\r\n");
        public static BasicResource Gry090 = new BasicResource("gry090",
            "textures/flatlist/gry090.bmp.ctxr,stage/XXXX/cache/gry090.bmp.ctxr,eu/stage/XXXX/cache/009e05c5/005d4825.ctxr\r\r\n");
        public static BasicResource GunLightF = new BasicResource("gun_light_f",
            "textures/flatlist/gun_light_f.bmp.ctxr,stage/XXXX/cache/gun_light_f.bmp.ctxr,eu/stage/XXXX/cache/009e05c5/00b6f1c9.ctxr\r\r\n");
        public static BasicResource GunLightS = new BasicResource("gun_light_s",
            "textures/flatlist/gun_light_s.bmp.ctxr,stage/XXXX/cache/gun_light_s.bmp.ctxr,eu/stage/XXXX/cache/009e05c5/00b6f1d6.ctxr\r\r\n");
        public static BasicResource ItemGlass = new BasicResource("item_glass",
            "textures/flatlist/item_glass.bmp.ctxr,stage/XXXX/cache/item_glass.bmp.ctxr,eu/stage/XXXX/cache/009e05c5/003ed6e5.ctxr\r\r\n");
        public static BasicResource ItemGrass2 = new BasicResource("item_grass2",
            "textures/flatlist/item_grass2.bmp.ctxr,stage/XXXX/cache/item_grass2.bmp.ctxr,eu/stage/XXXX/cache/009e05c5/003adcda.ctxr\r\r\n");
        public static BasicResource ItemGrass3 = new BasicResource("item_grass3",
            "textures/flatlist/item_grass3.bmp.ctxr,stage/XXXX/cache/item_grass3.bmp.ctxr,eu/stage/XXXX/cache/009e05c5/003adcdb.ctxr\r\r\n");
        public static KmsResource DemoM4GrnBul = new KmsResource("demo_m4_grn_bul",
            path: "assets/kms/us/demo_m4_grn_bul.kms,us/stage/XXXX/cache/00b932da.kms,cache/00b932da.kms\r\r\n",
            cmdl: "assets/kms/us/demo_m4_grn_bul.cmdl,us/stage/XXXX/cache/00b932da.cmdl,eu/stage/XXXX/cache/00b932da.cmdl\r\r\n");
        public static KmsResource DemoM4GrnEmb = new KmsResource("demo_m4_grn_emb",
            path: "assets/kms/us/demo_m4_grn_emb.kms,us/stage/XXXX/cache/00b93dd0.kms,cache/00b93dd0.kms\r\r\n",
            cmdl: "assets/kms/us/demo_m4_grn_emb.cmdl,us/stage/XXXX/cache/00b93dd0.cmdl,eu/stage/XXXX/cache/00b93dd0.cmdl\r\r\n");
        public static KmsResource SelSling1 = new KmsResource("sel_sling1",
            path: "assets/kms/us/sel_sling1.kms,us/stage/XXXX/cache/00bebdcc.kms,cache/00bebdcc.kms\r\r\n",
            cmdl: "assets/kms/us/sel_sling1.cmdl,us/stage/XXXX/cache/00bebdcc.cmdl,eu/stage/XXXX/cache/00bebdcc.cmdl\r\r\n");
        public static KmsResource SelSling2 = new KmsResource("sel_sling2",
            path: "assets/kms/us/sel_sling2.kms,us/stage/XXXX/cache/00bebdcd.kms,cache/00bebdcd.kms\r\r\n",
            cmdl: "assets/kms/us/sel_sling2.cmdl,us/stage/XXXX/cache/00bebdcd.cmdl,eu/stage/XXXX/cache/00bebdcd.cmdl\r\r\n");
    }
    
    public class BasicResource
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public string Id { get; set; }
        public bool ReplaceExistingId { get; set; }

        public BasicResource(string name, string path, bool replaceExistingId = false)
        {
            Name = name;
            Path = path;
            Id = path.Substring(path.LastIndexOf('/') + 1, 8);
            ReplaceExistingId = replaceExistingId;
        }
    }
    
    public class CtxrResource : BasicResource
    {
        public string Tri { get; set; }
        public CtxrResource(string name, string path, string tri, bool replaceExistingId = false) : base(name, path)
        {
            Name = name;
            Path = path;
            Tri = tri;
            Id = path.Substring(path.LastIndexOf('/') + 1, 8);
            ReplaceExistingId = replaceExistingId;
        }
    }
    
    public class KmsResource : BasicResource
    {
        public string Cmdl { get; set; }
        
        public KmsResource(string name, string path, string cmdl, bool replaceExistingId = false) : base(name, path)
        {
            Name = name;
            Cmdl = cmdl;
            Path = path;
            Id = path.Substring(path.LastIndexOf('/') + 1, 8);
            ReplaceExistingId = replaceExistingId;
        }
    }

    public class Resource
    {
        public static List<BasicResource> GuardResourceList = new List<BasicResource> 
        {
            MGS2Resource.ShlLit2, MGS2Resource.ShlLit1, MGS2Resource.ShlFrg1,
            MGS2Resource.ShlChi5, MGS2Resource.ShlChi4, MGS2Resource.ShlChi3, MGS2Resource.ShlChi2, MGS2Resource.ShlChi1,
            MGS2Resource.ShlBul6, MGS2Resource.ShlBul5, MGS2Resource.ShlBul4, MGS2Resource.ShlBul3, MGS2Resource.ShlBul2,
            MGS2Resource.ShlBul1, MGS2Resource.ShlBlu3, MGS2Resource.ShlBlu2, MGS2Resource.ShlBlu1, MGS2Resource.ShlBlr3,
            MGS2Resource.ShlBlr2, MGS2Resource.ShlBlr1, MGS2Resource.ShlBll3, MGS2Resource.ShlBll2, MGS2Resource.ShlBll1,
            MGS2Resource.ShlBld3, MGS2Resource.ShlBld2, MGS2Resource.ShlBld1, MGS2Resource.ShlAcr, MGS2Resource.Shl,
            MGS2Resource.SpecialGuardMar2, MGS2Resource.SpecialGuardSar3, MGS2Resource.ShlBul1Texture, MGS2Resource.ShlBul2Texture, MGS2Resource.ShlBul3Texture,
            MGS2Resource.ShlBul4Texture, MGS2Resource.ShlBul5Texture, MGS2Resource.ShlBul6Texture, MGS2Resource.ShlChi1Texture, MGS2Resource.ShlChi2Texture,
            MGS2Resource.ShlChi3Texture, MGS2Resource.ShlChi4Texture, MGS2Resource.ShlChi5Texture, MGS2Resource.ShlF1Texture, MGS2Resource.ShlF2Texture,
            MGS2Resource.ShlF3Texture, MGS2Resource.ShlFrgTexture, MGS2Resource.ShlLitWireTexture, MGS2Resource.ShlLit1BTexture, MGS2Resource.ShlLit1FTexture,
            MGS2Resource.ShlLit1FMskDecalTexture, MGS2Resource.ShlLit1F2Texture, MGS2Resource.ShlSAlpTexture, MGS2Resource.ComdlCacheStageA02aTri, MGS2Resource.SpsStageA12b,
            MGS2Resource.SpsEmbStageA12b, MGS2Resource.SpsAmoStageA12b, MGS2Resource.SpsAll2MskTexture, MGS2Resource.SpsEmbTexture, MGS2Resource.SpecialGuardMar1,
            MGS2Resource.SpecialGuardSar2, MGS2Resource.SpecialGuardTransCacheTri, MGS2Resource.ShotgunGuardTri, MGS2Resource.HtcArmUc0033ac05, MGS2Resource.HtcArmUc00fbbaaf,
            MGS2Resource.HtcBeltN2, MGS2Resource.HtcBeltUc, MGS2Resource.HtcBloodAlpOvl, MGS2Resource.HtcBodyBUc, MGS2Resource.HtcBodyUc,
            MGS2Resource.HtcEye2OvlHlf, MGS2Resource.HtcEye2OvlSubAlp, MGS2Resource.HtcFaceUc, MGS2Resource.HtcGunFro, MGS2Resource.HtcGunSide,
            MGS2Resource.HtcGunTop, MGS2Resource.HtcHandIUc0033ac05, MGS2Resource.HtcHandIUc00fbbaaf, MGS2Resource.HtcHandOUc0033ac05, MGS2Resource.HtcHandOUc00fbbaaf,
            MGS2Resource.HtcHelmetBUc, MGS2Resource.HtcHelmetBUcOvlAlpSub, MGS2Resource.HtcHelmetIUc, MGS2Resource.HtcHelmetUc, MGS2Resource.HtcHelmetUcOvlAlpSub,
            MGS2Resource.HtcLegUc, MGS2Resource.HtcLightUc, MGS2Resource.HtcLightUcOvlSubAlp, MGS2Resource.HtcNeckIUc, MGS2Resource.HtcNeckOUc,
            MGS2Resource.HtcPorchUc, MGS2Resource.HtcShoesUc, MGS2Resource.HtcShoulderUc, MGS2Resource.HtcShoulderUcOvlSubAlp, MGS2Resource.HtcUcOvlMod1120AlpEmap,
            MGS2Resource.HtcUnderPadUc, MGS2Resource.HtcdtOvlMod1120AlpEmap, MGS2Resource.SnaM9Glip, MGS2Resource.HtcBloodFace, MGS2Resource.HtcDefMt,
            MGS2Resource.HtcHandDef, MGS2Resource.M4GrnHtc, MGS2Resource.M4aGrnAmoHtc, MGS2Resource.HtcHandDefTri, MGS2Resource.HtcDefMtTri,
            MGS2Resource.HtcHandDefCv2, MGS2Resource.HtcHand5, MGS2Resource.HtcHand4, MGS2Resource.HtcHand3, MGS2Resource.HtcHand2,
            MGS2Resource.HtcHand1, MGS2Resource.HtcDefMtCv2, MGS2Resource.M4Alp, MGS2Resource.M4aAll, MGS2Resource.M4aGlUnit,
            MGS2Resource.M4aSbS1, MGS2Resource.M4grnBulHigh, MGS2Resource.M4GrnEmb, MGS2Resource.M92Jyuukou, MGS2Resource.MkrvAll,
            MGS2Resource.RadMusen1002f5aa1, MGS2Resource.RadMusen100a142a1, MGS2Resource.RadMusen2, MGS2Resource.RadMusen3, MGS2Resource.RadMusen4,
            MGS2Resource.RadMusen5, MGS2Resource.SelSling1AlpOvl, MGS2Resource.SelSling2AlpOvl, MGS2Resource.SelSling3, MGS2Resource.UspAll,
            MGS2Resource.UspEmb, MGS2Resource.Brack010101, MGS2Resource.DogtagChainBlackMsk, MGS2Resource.GradationAlpOvl, MGS2Resource.GrsBlack,
            MGS2Resource.Gry090, MGS2Resource.GunLightF, MGS2Resource.GunLightS, MGS2Resource.ItemGlass, MGS2Resource.ItemGrass2,
            MGS2Resource.ItemGrass3, MGS2Resource.DemoM4GrnBul, MGS2Resource.DemoM4GrnEmb, MGS2Resource.SelSling1, MGS2Resource.SelSling2
        };

        public static List<BasicResource> ItemResourcesList = new List<BasicResource>
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
            MGS2Resource.RationTexture, MGS2Resource.MedicineBoxTexture
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
            return ItemResourcesList.Find(x => x.Name == name.ToLower()) ?? GuardResourceList.Find(x=>x.Name == name.ToLower());
        }
    }
}
