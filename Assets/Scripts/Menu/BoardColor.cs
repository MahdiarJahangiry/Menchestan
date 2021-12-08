using System;
using System.Collections.Generic;
using UnityEngine;

namespace Menchestan
{
    namespace GamePlay
    {
        namespace Board
        {
            public struct BoardColor
            {
                public enum ColorPalette
                {
                    None,
                    Absolute_Zero,      ///#0048BA	
                    Acid_Green,     ///#B0BF1A	
                    Aero,       ///#7CB9E8	
                    Aero_Blue,      ///#C9FFE5	
                    African_Violet,     ///#B284BE	
                    Air_Superiority_Blue,       ///#72A0C1	
                    Alabaster,      ///#EDEAE0	
                    Alice_Blue,     ///#F0F8FF	
                    Alloy_Orange,       ///#C46210	
                    Almond,     ///#EFDECD	
                    Amaranth,       ///#E52B50	
                    Amaranth_Mp,        ///#9F2B68	
                    Amaranth_Pink,      ///#F19CBB	
                    Amaranth_Purple,        ///#AB274F	
                    Amaranth_Red,       ///#D3212D	
                    Amazon,     ///#3B7A57	
                    Amber,      ///#FFBF00	
                    Amber_Sae_Ece,      ///#FF7E00	
                    Amethyst,       ///#9966CC	
                    Android_Green,      ///#A4C639	
                    Antique_Brass,      ///#CD9575	
                    Antique_Bronze,     ///#665D1E	
                    Antique_Fuchsia,        ///#915C83	
                    Antique_Ruby,       ///#841B2D	
                    Antique_White,      ///#FAEBD7	
                    Ao_English,     ///#008000	
                    Apple_Green,        ///#8DB600	
                    Apricot,        ///#FBCEB1	
                    Aqua,       ///#00FFFF	
                    Aquamarine,     ///#7FFFD4	
                    Arctic_Lime,        ///#D0FF14	
                    Army_Green,     ///#4B5320	
                    Artichoke,      ///#8F9779	
                    Arylide_Yellow,     ///#E9D66B	
                    Ash_Gray,       ///#B2BEB5	
                    Asparagus,      ///#87A96B	
                    Atomic_Tangerine,       ///#FF9966	
                    Auburn,     ///#A52A2A	
                    Aureolin,       ///#FDEE00	
                    Avocado,        ///#568203	
                    Azure,      ///#007FFF	
                    Azure_X11_Web_Color,        ///#F0FFFF	
                    Baby_Blue,      ///#89CFF0	
                    Baby_Blue_Eyes,     ///#A1CAF1	
                    Baby_Pink,      ///#F4C2C2	
                    Baby_Powder,        ///#FEFEFA	
                    Baker_Miller_Pink,      ///#FF91AF	
                    Banana_Mania,       ///#FAE7B5	
                    Barbie_Pink,        ///#DA1884	
                    Barn_Red,       ///#7C0A02	
                    Battleship_Grey,        ///#848482	
                    Beau_Blue,      ///#BCD4E6	
                    Beaver,     ///#9F8170	
                    Beige,      ///#F5F5DC	
                    Bdazzled_Blue,      ///#2E5894	
                    Big_Dip_Oruby,      ///#9C2542	
                    Bisque,     ///#FFE4C4	
                    Bistre,     ///#3D2B1F	
                    Bistre_Brown,       ///#967117	
                    Bitter_Lemon,       ///#CAE00D	
                    Bitter_Lime,        ///#BFFF00	
                    Bittersweet,        ///#FE6F5E	
                    Bittersweet_Shimmer,        ///#BF4F51	
                    Black,      ///#000000	
                    Black_Bean,     ///#3D0C02	
                    Black_Chocolate,        ///#1B1811	
                    Black_Coffee,       ///#3B2F2F	
                    Black_Coral,        ///#54626F	
                    Black_Olive,        ///#3B3C36	
                    Black_Shadows,      ///#BFAFB2	
                    Blanched_Almond,        ///#FFEBCD	
                    Blast_Off_Bronze,       ///#A57164	
                    Bleu_De_France,     ///#318CE7	
                    Blizzard_Blue,      ///#ACE5EE	
                    Blond,      ///#FAF0BE	
                    Blood_Red,      ///#660000	
                    Blue,       ///#0000FF	
                    Blue_Crayola,       ///#1F75FE	
                    Blue_Munsell,       ///#0093AF	
                    Blue_Ncs,       ///#0087BD	
                    Blue_Pantone,       ///#0018A8	
                    Blue_Pigment,       ///#333399	
                    Blue_Ryb,       ///#0247FE	
                    Blue_Bell,      ///#A2A2D0	
                    Blue_Gray,      ///#6699CC	
                    Blue_Green,     ///#0D98BA	
                    Blue_Green_Color_Wheel,     ///#064E40	
                    Blue_Jeans,     ///#5DADEC	
                    Blue_Sapphire,      ///#126180	
                    Blue_Violet,        ///#8A2BE2	
                    Blue_Violet_Crayola,        ///#7366BD	
                    Blue_Violet_Color_Wheel,        ///#4D1A7F	
                    Blue_Yonder,        ///#5072A7	
                    Bluetiful,      ///#3C69E7	
                    Blush,      ///#DE5D83	
                    Bole,       ///#79443B	
                    Bone,       ///#E3DAC9	
                    Bottle_Green,       ///#006A4E	
                    Brandy,     ///#87413F	
                    Brick_Red,      ///#CB4154	
                    Bright_Green,       ///#66FF00	
                    Bright_Lilac,       ///#D891EF	
                    Bright_Maroon,      ///#C32148	
                    Bright_Navy_Blue,       ///#1974D2	
                    Bright_Yellow_Crayola,      ///#FFAA1D	
                    Brilliant_Rose,     ///#FF55A3	
                    Brink_Pink,     ///#FB607F	
                    British_Racing_Green,       ///#004225	
                    Bronze,     ///#CD7F32	
                    Brown,      ///#88540B	
                    Brown_Sugar,        ///#AF6E4D	
                    Brunswick_Green,        ///#1B4D3E	
                    Bud_Green,      ///#7BB661	
                    Buff,       ///#F0DC82	
                    Burgundy,       ///#800020	
                    Burlywood,      ///#DEB887	
                    Burnished_Brown,        ///#A17A74	
                    Burnt_Orange,       ///#CC5500	
                    Burnt_Sienna,       ///#E97451	
                    Burnt_Umber,        ///#8A3324	
                    Byzantine,      ///#BD33A4	
                    Byzantium,      ///#702963	
                    Cadet,      ///#536872	
                    Cadet_Blue,     ///#5F9EA0	
                    Cadet_Blue_Crayola,     ///#A9B2C3	
                    Cadet_Grey,     ///#91A3B0	
                    Cadmium_Green,      ///#006B3C	
                    Cadmium_Orange,     ///#ED872D	
                    Cadmium_Red,        ///#E30022	
                    Cadmium_Yellow,     ///#FFF600	
                    Café_Au_Lait,       ///#A67B5B	
                    Café_Noir,      ///#4B3621	
                    Cambridge_Blue,     ///#A3C1AD	
                    Camel,      ///#C19A6B	
                    Cameo_Pink,     ///#EFBBCC	
                    Canary,     ///#FFFF99	
                    Canary_Yellow,      ///#FFEF00	
                    Candy_Apple_Red,        ///#FF0800	
                    Candy_Pink,     ///#E4717A	
                    Capri,      ///#00BFFF	
                    Caput_Mortuum,      ///#592720	
                    Cardinal,       ///#C41E3A	
                    Caribbean_Green,        ///#00CC99	
                    Carmine,        ///#960018	
                    Carmine_Mp,     ///#D70040	
                    Carnation_Pink,     ///#FFA6C9	
                    Carnelian,      ///#B31B1B	
                    Carolina_Blue,      ///#56A0D3	
                    Carrot_Orange,      ///#ED9121	
                    Castleton_Green,        ///#00563F	
                    Catawba,        ///#703642	
                    Cedar_Chest,        ///#C95A49	
                    Celadon,        ///#ACE1AF	
                    Celadon_Blue,       ///#007BA7	
                    Celadon_Green,      ///#2F847C	
                    Celeste,        ///#B2FFFF	
                    Celtic_Blue,        ///#246BCE	
                    Cerise,     ///#DE3163	
                    Cerulean,       ///#007BA7	
                    Cerulean_Blue,      ///#2A52BE	
                    Cerulean_Frost,     ///#6D9BC3	
                    Cerulean_Crayola,       ///#1DACD6	
                    Cg_Blue,        ///#007AA5	
                    Cg_Red,     ///#E03C31	
                    Champagne,      ///#F7E7CE	
                    Champagne_Pink,     ///#F1DDCF	
                    Charcoal,       ///#36454F	
                    Charleston_Green,       ///#232B2B	
                    Charm_Pink,     ///#E68FAC	
                    Chartreuse_Traditional,     ///#DFFF00	
                    Chartreuse_Web,     ///#7FFF00	
                    Cherry_Blossom_Pink,        ///#FFB7C5	
                    Chestnut,       ///#954535	
                    China_Pink,     ///#DE6FA1	
                    China_Rose,     ///#A8516E	
                    Chinese_Red,        ///#AA381E	
                    Chinese_Violet,     ///#856088	
                    Chinese_Yellow,     ///#FFB200	
                    Chocolate_Traditional,      ///#7B3F00	
                    Chocolate_Web,      ///#D2691E	
                    Chrome_Yellow,      ///#FFA700	
                    Cinereous,      ///#98817B	
                    Cinnabar,       ///#E34234	
                    Cinnamon_Satin,     ///#CD607E	
                    Citrine,        ///#E4D00A	
                    Citron,     ///#9FA91F	
                    Claret,     ///#7F1734	
                    Cobalt_Blue,        ///#0047AB	
                    Cocoa_Brown,        ///#D2691E	
                    Coffee,     ///#6F4E37	
                    Columbia_Blue,      ///#B9D9EB	
                    Congo_Pink,     ///#F88379	
                    Cool_Grey,      ///#8C92AC	
                    Copper,     ///#B87333	
                    Copper_Crayola,     ///#DA8A67	
                    Copper_Penny,       ///#AD6F69	
                    Copper_Red,     ///#CB6D51	
                    Copper_Rose,        ///#996666	
                    Coquelicot,     ///#FF3800	
                    Coral,      ///#FF7F50	
                    Coral_Pink,     ///#F88379	
                    Cordovan,       ///#893F45	
                    Corn,       ///#FBEC5D	
                    Cornflower_Blue,        ///#6495ED	
                    Cornsilk,       ///#FFF8DC	
                    Cosmic_Cobalt,      ///#2E2D88	
                    Cosmic_Latte,       ///#FFF8E7	
                    Coyote_Brown,       ///#81613C	
                    Cotton_Candy,       ///#FFBCD9	
                    Cream,      ///#FFFDD0	
                    Crimson,        ///#DC143C	
                    Crimson_Ua,     ///#9E1B32	
                    Cultured,       ///#F5F5F5	
                    Cyan,       ///#00FFFF	
                    Cyan_Process,       ///#00B7EB	
                    Cyber_Grape,        ///#58427C	
                    Cyber_Yellow,       ///#FFD300	
                    Cyclamen,       ///#F56FA1	
                    Dark_Blue_Gray,     ///#666699	
                    Dark_Brown,     ///#654321	
                    Dark_Byzantium,     ///#5D3954	
                    Dark_Cornflower_Blue,       ///#26428B	
                    Dark_Cyan,      ///#008B8B	
                    Dark_Electric_Blue,     ///#536878	
                    Dark_Goldenrod,     ///#B8860B	
                    Dark_Green,     ///#013220	
                    Dark_Green_X11,     ///#006400	
                    Dark_Jungle_Green,      ///#1A2421	
                    Dark_Khaki,     ///#BDB76B	
                    Dark_Lava,      ///#483C32	
                    Dark_Liver,     ///#534B4F	
                    Dark_Liver_Horses,      ///#543D37	
                    Dark_Magenta,       ///#8B008B	
                    Dark_Moss_Green,        ///#4A5D23	
                    Dark_Olive_Green,       ///#556B2F	
                    Dark_Orange,        ///#FF8C00	
                    Dark_Orchid,        ///#9932CC	
                    Dark_Pastel_Green,      ///#03C03C	
                    Dark_Purple,        ///#301934	
                    Dark_Red,       ///#8B0000	
                    Dark_Salmon,        ///#E9967A	
                    Dark_Sea_Green,     ///#8FBC8F	
                    Dark_Sienna,        ///#3C1414	
                    Dark_Sky_Blue,      ///#8CBED6	
                    Dark_Slate_Blue,        ///#483D8B	
                    Dark_Slate_Gray,        ///#2F4F4F	
                    Dark_Spring_Green,      ///#177245	
                    Dark_Turquoise,     ///#00CED1	
                    Dark_Violet,        ///#9400D3	
                    Dartmouth_Green,        ///#00703C	
                    Davys_Grey,     ///#555555	
                    Deep_Cerise,        ///#DA3287	
                    Deep_Champagne,     ///#FAD6A5	
                    Deep_Chestnut,      ///#B94E48	
                    Deep_Jungle_Green,      ///#004B49	
                    Deep_Pink,      ///#FF1493	
                    Deep_Saffron,       ///#FF9933	
                    Deep_Sky_Blue,      ///#00BFFF	
                    Deep_Space_Sparkle,     ///#4A646C	
                    Deep_Taupe,     ///#7E5E60	
                    Denim,      ///#1560BD	
                    Denim_Blue,     ///#2243B6	
                    Desert,     ///#C19A6B	
                    Desert_Sand,        ///#EDC9AF	
                    Dim_Gray,       ///#696969	
                    Dodger_Blue,        ///#1E90FF	
                    Dogwood_Rose,       ///#D71868	
                    Drab,       ///#967117	
                    Duke_Blue,      ///#00009C	
                    Dutch_White,        ///#EFDFBB	
                    Earth_Yellow,       ///#E1A95F	
                    Ebony,      ///#555D50	
                    Ecru,       ///#C2B280	
                    Eerie_Black,        ///#1B1B1B	
                    Eggplant,       ///#614051	
                    Eggshell,       ///#F0EAD6	
                    Egyptian_Blue,      ///#1034A6	
                    Electric_Blue,      ///#7DF9FF	
                    Electric_Green,     ///#00FF00	
                    Electric_Indigo,        ///#6F00FF	
                    Electric_Lime,      ///#CCFF00	
                    Electric_Purple,        ///#BF00FF	
                    Electric_Violet,        ///#8F00FF	
                    Emerald,        ///#50C878	
                    Eminence,       ///#6C3082	
                    English_Green,      ///#1B4D3E	
                    English_Lavender,       ///#B48395	
                    English_Red,        ///#AB4B52	
                    English_Vermillion,     ///#CC474B	
                    English_Violet,     ///#563C5C	
                    Erin,       ///#00FF40	
                    Eton_Blue,      ///#96C8A2	
                    Fallow,     ///#C19A6B	
                    Falu_Red,       ///#801818	
                    Fandango,       ///#B53389	
                    Fandango_Pink,      ///#DE5285	
                    Fashion_Fuchsia,        ///#F400A1	
                    Fawn,       ///#E5AA70	
                    Feldgrau,       ///#4D5D53	
                    Fern_Green,     ///#4F7942	
                    Field_Drab,     ///#6C541E	
                    Fiery_Rose,     ///#FF5470	
                    Firebrick,      ///#B22222	
                    Fire_Engine_Red,        ///#CE2029	
                    Fire_Opal,      ///#E95C4B	
                    Flame,      ///#E25822	
                    Flax,       ///#EEDC82	
                    Flickr_Blue,        ///#0063dc	
                    Flickr_Pink,        ///#FB0081	
                    Flirt,      ///#A2006D	
                    Floral_White,       ///#FFFAF0	
                    Fluorescent_Blue,       ///#15F4EE	
                    Forest_Green_Crayola,       ///#5FA777	
                    Forest_Green_Traditional,       ///#014421	
                    Forest_Green_Web,       ///#228B22	
                    French_Beige,       ///#A67B5B	
                    French_Bistre,      ///#856D4D	
                    French_Blue,        ///#0072BB	
                    French_Fuchsia,     ///#FD3F92	
                    French_Lilac,       ///#86608E	
                    French_Lime,        ///#9EFD38	
                    French_Mauve,       ///#D473D4	
                    French_Pink,        ///#FD6C9E	
                    French_Raspberry,       ///#C72C48	
                    French_Rose,        ///#F64A8A	
                    French_Sky_Blue,        ///#77B5FE	
                    French_Violet,      ///#8806CE	
                    Frostbite,      ///#E936A7	
                    Fuchsia,        ///#FF00FF	
                    Fuchsia_Crayola,        ///#C154C1	
                    Fuchsia_Purple,     ///#CC397B	
                    Fuchsia_Rose,       ///#C74375	
                    Fulvous,        ///#E48400	
                    Fuzzy_Wuzzy,        ///#87421F	
                    Gainsboro,      ///#DCDCDC	
                    Gamboge,        ///#E49B0F	
                    Generic_Viridian,       ///#007F66	
                    Ghost_White,        ///#F8F8FF	
                    Glaucous,       ///#6082B6	
                    Glossy_Grape,       ///#AB92B3	
                    Go_Green,       ///#00AB66	
                    Gold,       ///#A57C00	
                    Gold_Metallic,      ///#D4AF37	
                    Gold_Web_Golden,        ///#FFD700	
                    Gold_Crayola,       ///#E6BE8A	
                    Gold_Fusion,        ///#85754E	
                    Golden_Brown,       ///#996515	
                    Golden_Poppy,       ///#FCC200	
                    Golden_Yellow,      ///#FFDF00	
                    Goldenrod,      ///#DAA520	
                    Granite_Gray,       ///#676767	
                    Granny_Smith_Apple,     ///#A8E4A0	
                    Gray_Web,       ///#808080	
                    Gray_X11_Gray,      ///#BEBEBE	
                    Green,      ///#00FF00	
                    Green_Crayola,      ///#1CAC78	
                    Green_Web,      ///#008000	
                    Green_Munsell,      ///#00A877	
                    Green_Ncs,      ///#009F6B	
                    Green_Pantone,      ///#00AD43	
                    Green_Pigment,      ///#00A550	
                    Green_Ryb,      ///#66B032	
                    Green_Blue,     ///#1164B4	
                    Green_Blue_Crayola,     ///#2887C8	
                    Green_Cyan,     ///#009966	
                    Green_Lizard,       ///#A7F432	
                    Green_Sheen,        ///#6EAEA1	
                    Green_Yellow,       ///#ADFF2F	
                    Green_Yellow_Crayola,       ///#F0E891	
                    Grullo,     ///#A99A86	
                    Gunmetal,       ///#2a3439	
                    Han_Blue,       ///#446CCF	
                    Han_Purple,     ///#5218FA	
                    Hansa_Yellow,       ///#E9D66B	
                    Harlequin,      ///#3FFF00	
                    Harvest_Gold,       ///#DA9100	
                    Heat_Wave,      ///#FF7A00	
                    Heliotrope,     ///#DF73FF	
                    Heliotrope_Gray,        ///#AA98A9	
                    Hollywood_Cerise,       ///#F400A1	
                    Honeydew,       ///#F0FFF0	
                    Honolulu_Blue,      ///#006DB0	
                    Hookers_Green,      ///#49796B	
                    Hot_Magenta,        ///#FF1DCE	
                    Hot_Pink,       ///#FF69B4	
                    Hunter_Green,       ///#355E3B	
                    Iceberg,        ///#71A6D2	
                    Icterine,       ///#FCF75E	
                    Illuminating_Emerald,       ///#319177	
                    Imperial_Red,       ///#ED2939	
                    Inchworm,       ///#B2EC5D	
                    Independence,       ///#4C516D	
                    India_Green,        ///#138808	
                    Indian_Red,     ///#CD5C5C	
                    Indian_Yellow,      ///#E3A857	
                    Indigo,     ///#4B0082	
                    Indigo_Dye,     ///#00416A	
                    International_Klein_Blue,       ///#002FA7	
                    International_Orange_Aerospace,     ///#FF4F00	
                    International_Orange_Engineering,       ///#BA160C	
                    International_Orange_Golden_Gate_Bridge,        ///#C0362C	
                    Iris,       ///#5A4FCF	
                    Irresistible,       ///#B3446C	
                    Isabelline,     ///#F4F0EC	
                    Italian_Sky_Blue,       ///#B2FFFF	
                    Ivory,      ///#FFFFF0	
                    Jade,       ///#00A86B	
                    Jasmine,        ///#F8DE7E	
                    Jazzberry_Jam,      ///#A50B5E	
                    Jet,        ///#343434	
                    Jonquil,        ///#F4CA16	
                    June_Bud,       ///#BDDA57	
                    Jungle_Green,       ///#29AB87	
                    Kelly_Green,        ///#4CBB17	
                    Keppel,     ///#3AB09E	
                    Key_Lime,       ///#E8F48C	
                    Khaki_Web,      ///#C3B091	
                    Khaki_X11_Light_Khaki,      ///#F0E68C	
                    Kobe,       ///#882D17	
                    Kobi,       ///#E79FC4	
                    Kobicha,        ///#6B4423	
                    Kombu_Green,        ///#354230	
                    Ksu_Purple,     ///#512888	
                    Languid_Lavender,       ///#D6CADD	
                    Lapis_Lazuli,       ///#26619C	
                    Laser_Lemon,        ///#FFFF66	
                    Laurel_Green,       ///#A9BA9D	
                    Lava,       ///#CF1020	
                    Lavender_Floral,        ///#B57EDC	
                    Lavender_Web,       ///#E6E6FA	
                    Lavender_Blue,      ///#CCCCFF	
                    Lavender_Blush,     ///#FFF0F5	
                    Lavender_Gray,      ///#C4C3D0	
                    Lawn_Green,     ///#7CFC00	
                    Lemon,      ///#FFF700	
                    Lemon_Chiffon,      ///#FFFACD	
                    Lemon_Curry,        ///#CCA01D	
                    Lemon_Glacier,      ///#FDFF00	
                    Lemon_Meringue,     ///#F6EABE	
                    Lemon_Yellow,       ///#FFF44F	
                    Lemon_Yellow_Crayola,       ///#FFFF9F	
                    Liberty,        ///#545AA7	
                    Light_Blue,     ///#ADD8E6	
                    Light_Coral,        ///#F08080	
                    Light_Cornflower_Blue,      ///#93CCEA	
                    Light_Cyan,     ///#E0FFFF	
                    Light_French_Beige,     ///#C8AD7F	
                    Light_Goldenrod_Yellow,     ///#FAFAD2	
                    Light_Gray,     ///#D3D3D3	
                    Light_Green,        ///#90EE90	
                    Light_Orange,       ///#FED8B1	
                    Light_Periwinkle,       ///#C5CBE1	
                    Light_Pink,     ///#FFB6C1	
                    Light_Salmon,       ///#FFA07A	
                    Light_Sea_Green,        ///#20B2AA	
                    Light_Sky_Blue,     ///#87CEFA	
                    Light_Slate_Gray,       ///#778899	
                    Light_Steel_Blue,       ///#B0C4DE	
                    Light_Yellow,       ///#FFFFE0	
                    Lilac,      ///#C8A2C8	
                    Lilac_Luster,       ///#AE98AA	
                    Lime_Color_Wheel,       ///#BFFF00	
                    Lime_Web_X11_Green,     ///#00FF00	
                    Lime_Green,     ///#32CD32	
                    Lincoln_Green,      ///#195905	
                    Linen,      ///#FAF0E6	
                    Lion,       ///#C19A6B	
                    Liseran_Purple,     ///#DE6FA1	
                    Little_Boy_Blue,        ///#6CA0DC	
                    Liver,      ///#674C47	
                    Liver_Dogs,     ///#B86D29	
                    Liver_Organ,        ///#6C2E1F	
                    Liver_Chestnut,     ///#987456	
                    Livid,      ///#6699CC	
                    Macaroni_And_Cheese,        ///#FFBD88	
                    Madder_Lake,        ///#CC3336	
                    Magenta,        ///#FF00FF	
                    Magenta_Crayola,        ///#F653A6	
                    Magenta_Dye,        ///#CA1F7B	
                    Magenta_Pantone,        ///#D0417E	
                    Magenta_Process,        ///#FF0090	
                    Magenta_Haze,       ///#9F4576	
                    Magic_Mint,     ///#AAF0D1	
                    Magnolia,       ///#F2E8D7	
                    Mahogany,       ///#C04000	
                    Maize,      ///#FBEC5D	
                    Maize_Crayola,      ///#F2C649	
                    Majorelle_Blue,     ///#6050DC	
                    Malachite,      ///#0BDA51	
                    Manatee,        ///#979AAA	
                    Mandarin,       ///#F37A48	
                    Mango,      ///#FDBE02	
                    Mango_Tango,        ///#FF8243	
                    Mantis,     ///#74C365	
                    Mardi_Gras,     ///#880085	
                    Marigold,       ///#EAA221	
                    Maroon_Crayola,     ///#C32148	
                    Maroon_Web,     ///#800000	
                    Maroon_X11,     ///#B03060	
                    Mauve,      ///#E0B0FF	
                    Mauve_Taupe,        ///#915F6D	
                    Mauvelous,      ///#EF98AA	
                    Maximum_Blue,       ///#47ABCC	
                    Maximum_Blue_Green,     ///#30BFBF	
                    Maximum_Blue_Purple,        ///#ACACE6	
                    Maximum_Green,      ///#5E8C31	
                    Maximum_Green_Yellow,       ///#D9E650	
                    Maximum_Purple,     ///#733380	
                    Maximum_Red,        ///#D92121	
                    Maximum_Red_Purple,     ///#A63A79	
                    Maximum_Yellow,     ///#FAFA37	
                    Maximum_Yellow_Red,     ///#F2BA49	
                    May_Green,      ///#4C9141	
                    Maya_Blue,      ///#73C2FB	
                    Medium_Aquamarine,      ///#66DDAA	
                    Medium_Blue,        ///#0000CD	
                    Medium_Candy_Apple_Red,     ///#E2062C	
                    Medium_Carmine,     ///#AF4035	
                    Medium_Champagne,       ///#F3E5AB	
                    Medium_Orchid,      ///#BA55D3	
                    Medium_Purple,      ///#9370DB	
                    Medium_Sea_Green,       ///#3CB371	
                    Medium_Slate_Blue,      ///#7B68EE	
                    Medium_Spring_Green,        ///#00FA9A	
                    Medium_Turquoise,       ///#48D1CC	
                    Medium_Violet_Red,      ///#C71585	
                    Mellow_Apricot,     ///#F8B878	
                    Mellow_Yellow,      ///#F8DE7E	
                    Melon,      ///#FEBAAD	
                    Metallic_Gold,      ///#D3AF37	
                    Metallic_Seaweed,       ///#0A7E8C	
                    Metallic_Sunburst,      ///#9C7C38	
                    Mexican_Pink,       ///#E4007C	
                    Middle_Blue,        ///#7ED4E6	
                    Middle_Blue_Green,      ///#8DD9CC	
                    Middle_Blue_Purple,     ///#8B72BE	
                    Middle_Grey,        ///#8B8680	
                    Middle_Green,       ///#4D8C57	
                    Middle_Green_Yellow,        ///#ACBF60	
                    Middle_Purple,      ///#D982B5	
                    Middle_Red,     ///#E58E73	
                    Middle_Red_Purple,      ///#A55353	
                    Middle_Yellow,      ///#FFEB00	
                    Middle_Yellow_Red,      ///#ECB176	
                    Midnight,       ///#702670	
                    Midnight_Blue,      ///#191970	
                    Midnight_Green_Eagle_Green,     ///#004953	
                    Mikado_Yellow,      ///#FFC40C	
                    Mimi_Pink,      ///#FFDAE9	
                    Mindaro,        ///#E3F988	
                    Ming,       ///#36747D	
                    Minion_Yellow,      ///#F5E050	
                    Mint,       ///#3EB489	
                    Mint_Cream,     ///#F5FFFA	
                    Mint_Green,     ///#98FF98	
                    Misty_Moss,     ///#BBB477	
                    Misty_Rose,     ///#FFE4E1	
                    Mode_Beige,     ///#967117	
                    Morning_Blue,       ///#8DA399	
                    Moss_Green,     ///#8A9A5B	
                    Mountain_Meadow,        ///#30BA8F	
                    Mountbatten_Pink,       ///#997A8D	
                    Msu_Green,      ///#18453B	
                    Mulberry,       ///#C54B8C	
                    Mulberry_Crayola,       ///#C8509B	
                    Mustard,        ///#FFDB58	
                    Myrtle_Green,       ///#317873	
                    Mystic,     ///#D65282	
                    Mystic_Maroon,      ///#AD4379	
                    Nadeshiko_Pink,     ///#F6ADC6	
                    Naples_Yellow,      ///#FADA5E	
                    Navajo_White,       ///#FFDEAD	
                    Navy_Blue,      ///#000080	
                    Navy_Blue_Crayola,      ///#1974D2	
                    Neon_Blue,      ///#4666FF	
                    Neon_Green,     ///#39FF14	
                    New_York_Pink,      ///#D7837F	
                    Nickel,     ///#727472	
                    Non_Photo_Blue,     ///#A4DDED	
                    Nyanza,     ///#E9FFDB	
                    Ocean_Blue,     ///#4F42B5	
                    Ocean_Green,        ///#48BF91	
                    Ochre,      ///#CC7722	
                    Old_Burgundy,       ///#43302E	
                    Old_Gold,       ///#CFB53B	
                    Old_Lace,       ///#FDF5E6	
                    Old_Lavender,       ///#796878	
                    Old_Mauve,      ///#673147	
                    Old_Rose,       ///#C08081	
                    Old_Silver,     ///#848482	
                    Olive,      ///#808000	
                    Olive_Drab3,        ///#6B8E23	
                    Olive_Drab7,        ///#3C341F	
                    Olive_Green,        ///#B5B35C	
                    Olivine,        ///#9AB973	
                    Onyx,       ///#353839	
                    Opal,       ///#A8C3BC	
                    Opera_Mauve,        ///#B784A7	
                    Orange,     ///#FF7F00	
                    Orange_Crayola,     ///#FF7538	
                    Orange_Pantone,     ///#FF5800	
                    Orange_Web,     ///#FFA500	
                    Orange_Peel,        ///#FF9F00	
                    Orange_Red,     ///#FF681F	
                    Orange_Red_Crayola,     ///#FF5349	
                    Orange_Soda,        ///#FA5B3D	
                    Orange_Yellow,      ///#F5BD1F	
                    Orange_Yellow_Crayola,      ///#F8D568	
                    Orchid,     ///#DA70D6	
                    Orchid_Pink,        ///#F2BDCD	
                    Orchid_Crayola,     ///#E29CD2	
                    Outer_Space_Crayola,        ///#2D383A	
                    Outrageous_Orange,      ///#FF6E4A	
                    Oxblood,        ///#800020	
                    Oxford_Blue,        ///#002147	
                    Ou_Crimson_Red,     ///#841617	
                    Pacific_Blue,       ///#1CA9C9	
                    Pakistan_Green,     ///#006600	
                    Palatinate_Purple,      ///#682860	
                    Pale_Aqua,      ///#BCD4E6	
                    Pale_Cerulean,      ///#9BC4E2	
                    Pale_Pink,      ///#FADADD	
                    Pale_Purple_Pantone,        ///#FAE6FA	
                    Pale_Silver,        ///#C9C0BB	
                    Pale_Spring_Bud,        ///#ECEBBD	
                    Pansy_Purple,       ///#78184A	
                    Paolo_Veronese_Green,       ///#009B7D	
                    Papaya_Whip,        ///#FFEFD5	
                    Paradise_Pink,      ///#E63E62	
                    Paris_Green,        ///#50C878	
                    Pastel_Pink,        ///#DEA5A4	
                    Patriarch,      ///#800080	
                    Paynes_Grey,        ///#536878	
                    Peach,      ///#FFE5B4	
                    Peach_Crayola,      ///#FFCBA4	
                    Peach_Puff,     ///#FFDAB9	
                    Pear,       ///#D1E231	
                    Pearly_Purple,      ///#B768A2	
                    Periwinkle,     ///#CCCCFF	
                    Periwinkle_Crayola,     ///#C3CDE6	
                    Permanent_Geranium_Lake,        ///#E12C2C	
                    Persian_Blue,       ///#1C39BB	
                    Persian_Green,      ///#00A693	
                    Persian_Indigo,     ///#32127A	
                    Persian_Orange,     ///#D99058	
                    Persian_Pink,       ///#F77FBE	
                    Persian_Plum,       ///#701C1C	
                    Persian_Red,        ///#CC3333	
                    Persian_Rose,       ///#FE28A2	
                    Persimmon,      ///#EC5800	
                    Pewter_Blue,        ///#8BA8B7	
                    Phlox,      ///#DF00FF	
                    Phthalo_Blue,       ///#000F89	
                    Phthalo_Green,      ///#123524	
                    Picotee_Blue,       ///#2E2787	
                    Pictorial_Carmine,      ///#C30B4E	
                    Piggy_Pink,     ///#FDDDE6	
                    Pine_Green,     ///#01796F	
                    Pine_Tree,      ///#2A2F23	
                    Pink,       ///#FFC0CB	
                    Pink_Pantone,       ///#D74894	
                    Pink_Flamingo,      ///#FC74FD	
                    Pink_Lace,      ///#FFDDF4	
                    Pink_Lavender,      ///#D8B2D1	
                    Pink_Sherbet,       ///#F78FA7	
                    Pistachio,      ///#93C572	
                    Platinum,       ///#E5E4E2	
                    Plum,       ///#8E4585	
                    Plum_Web,       ///#DDA0DD	
                    Plump_Purple,       ///#5946B2	
                    Polished_Pine,      ///#5DA493	
                    Pomp_And_Power,     ///#86608E	
                    Popstar,        ///#BE4F62	
                    Portland_Orange,        ///#FF5A36	
                    Powder_Blue,        ///#B0E0E6	
                    Princeton_Orange,       ///#F58025	
                    Prune,      ///#701C1C	
                    Prussian_Blue,      ///#003153	
                    Psychedelic_Purple,     ///#DF00FF	
                    Puce,       ///#CC8899	
                    Pullman_Brown_Ups_Brown,        ///#644117	
                    Pumpkin,        ///#FF7518	
                    Purple,     ///#6A0DAD	
                    Purple_Web,     ///#800080	
                    Purple_Munsell,     ///#9F00C5	
                    Purple_X11,     ///#A020F0	
                    Purple_Mountain_Majesty,        ///#9678B6	
                    Purple_Navy,        ///#4E5180	
                    Purple_Pizzazz,     ///#FE4EDA	
                    Purple_Plum,        ///#9C51B6	
                    Purpureus,      ///#9A4EAE	
                    Queen_Blue,     ///#436B95	
                    Queen_Pink,     ///#E8CCD7	
                    Quick_Silver,       ///#A6A6A6	
                    Quinacridone_Magenta,       ///#8E3A59	
                    Radical_Red,        ///#FF355E	
                    Raisin_Black,       ///#242124	
                    Rajah,      ///#FBAB60	
                    Raspberry,      ///#E30B5D	
                    Raspberry_Glace,        ///#915F6D	
                    Raspberry_Rose,     ///#B3446C	
                    Raw_Sienna,     ///#D68A59	
                    Raw_Umber,      ///#826644	
                    Razzle_Dazzle_Rose,     ///#FF33CC	
                    Razzmatazz,     ///#E3256B	
                    Razzmic_Berry,      ///#8D4E85	
                    Rebecca_Purple,     ///#663399	
                    Red,        ///#FF0000	
                    Red_Crayola,        ///#EE204D	
                    Red_Munsell,        ///#F2003C	
                    Red_Ncs,        ///#C40233	
                    Red_Pantone,        ///#ED2939	
                    Red_Pigment,        ///#ED1C24	
                    Red_Ryb,        ///#FE2712	
                    Red_Orange,     ///#FF5349	
                    Red_Orange_Crayola,     ///#FF681F	
                    Red_Orange_Color_Wheel,     ///#FF4500	
                    Red_Purple,     ///#E40078	
                    Red_Salsa,      ///#FD3A4A	
                    Red_Violet,     ///#C71585	
                    Red_Violet_Crayola,     ///#C0448F	
                    Red_Violet_Color_Wheel,     ///#922B3E	
                    Redwood,        ///#A45A52	
                    Resolution_Blue,        ///#002387	
                    Rhythm,     ///#777696	
                    Rich_Black,     ///#004040	
                    Rich_Black_Fogra29,     ///#010B13	
                    Rich_Black_Fogra39,     ///#010203	
                    Rifle_Green,        ///#444C38	
                    Robin_Egg_Blue,     ///#00CCCC	
                    Rocket_Metallic,        ///#8A7F80	
                    Roman_Silver,       ///#838996	
                    Rose,       ///#FF007F	
                    Rose_Bonbon,        ///#F9429E	
                    Rose_Dust,      ///#9E5E6F	
                    Rose_Ebony,     ///#674846	
                    Rose_Madder,        ///#E32636	
                    Rose_Pink,      ///#FF66CC	
                    Rose_Quartz,        ///#AA98A9	
                    Rose_Red,       ///#C21E56	
                    Rose_Taupe,     ///#905D5D	
                    Rose_Vale,      ///#AB4E52	
                    Rosewood,       ///#65000B	
                    Rosso_Corsa,        ///#D40000	
                    Rosy_Brown,     ///#BC8F8F	
                    Royal_Blue_Dark,        ///#002366	
                    Royal_Blue_Light,       ///#4169E1	
                    Royal_Purple,       ///#7851A9	
                    Royal_Yellow,       ///#FADA5E	
                    Ruber,      ///#CE4676	
                    Rubine_Red,     ///#D10056	
                    Ruby,       ///#E0115F	
                    Ruby_Red,       ///#9B111E	
                    Rufous,     ///#A81C07	
                    Russet,     ///#80461B	
                    Russian_Green,      ///#679267	
                    Russian_Violet,     ///#32174D	
                    Rust,       ///#B7410E	
                    Rusty_Red,      ///#DA2C43	
                    Sacramento_State_Green,     ///#043927	
                    Saddle_Brown,       ///#8B4513	
                    Safety_Orange,      ///#FF7800	
                    Safety_Orange_Blaze_Orange,     ///#FF6700	
                    Safety_Yellow,      ///#EED202	
                    Saffron,        ///#F4C430	
                    Sage,       ///#BCB88A	
                    St_Patricks_Blue,       ///#23297A	
                    Salmon,     ///#FA8072	
                    Salmon_Pink,        ///#FF91A4	
                    Sand,       ///#C2B280	
                    Sand_Dune,      ///#967117	
                    Sandy_Brown,        ///#F4A460	
                    Sap_Green,      ///#507D2A	
                    Sapphire,       ///#0F52BA	
                    Sapphire_Blue,      ///#0067A5	
                    Sapphire_Crayola,       ///#0067A5	
                    Satin_Sheen_Gold,       ///#CBA135	
                    Scarlet,        ///#FF2400	
                    Schauss_Pink,       ///#FF91AF	
                    School_Bus_Yellow,      ///#FFD800	
                    Screamin_Green,     ///#66FF66	
                    Sea_Green,      ///#2E8B57	
                    Sea_Green_Crayola,      ///#00FFCD	
                    Seal_Brown,     ///#59260B	
                    Seashell,       ///#FFF5EE	
                    Selective_Yellow,       ///#FFBA00	
                    Sepia,      ///#704214	
                    Shadow,     ///#8A795D	
                    Shadow_Blue,        ///#778BA5	
                    Shamrock_Green,     ///#009E60	
                    Sheen_Green,        ///#8FD400	
                    Shimmering_Blush,       ///#D98695	
                    Shiny_Shamrock,     ///#5FA778	
                    Shocking_Pink,      ///#FC0FC0	
                    Shocking_Pink_Crayola,      ///#FF6FFF	
                    Sienna,     ///#882D17	
                    Silver,     ///#C0C0C0	
                    Silver_Crayola,     ///#C9C0BB	
                    Silver_Metallic,        ///#AAA9AD	
                    Silver_Chalice,     ///#ACACAC	
                    Silver_Pink,        ///#C4AEAD	
                    Silver_Sand,        ///#BFC1C2	
                    Sinopia,        ///#CB410B	
                    Sizzling_Red,       ///#FF3855	
                    Sizzling_Sunrise,       ///#FFDB00	
                    Skobeloff,      ///#007474	
                    Sky_Blue,       ///#87CEEB	
                    Sky_Blue_Crayola,       ///#76D7EA	
                    Sky_Magenta,        ///#CF71AF	
                    Slate_Blue,     ///#6A5ACD	
                    Slate_Gray,     ///#708090	
                    Slimy_Green,        ///#299617	
                    Smitten,        ///#C84186	
                    Smoky_Black,        ///#100C08	
                    Snow,       ///#FFFAFA	
                    Solid_Pink,     ///#893843	
                    Sonic_Silver,       ///#757575	
                    Space_Cadet,        ///#1D2951	
                    Spanish_Bistre,     ///#807532	
                    Spanish_Blue,       ///#0070B8	
                    Spanish_Carmine,        ///#D10047	
                    Spanish_Gray,       ///#989898	
                    Spanish_Green,      ///#009150	
                    Spanish_Orange,     ///#E86100	
                    Spanish_Pink,       ///#F7BFBE	
                    Spanish_Red,        ///#E60026	
                    Spanish_Sky_Blue,       ///#00FFFF	
                    Spanish_Violet,     ///#4C2882	
                    Spanish_Viridian,       ///#007F5C	
                    Spring_Bud,     ///#A7FC00	
                    Spring_Frost,       ///#87FF2A	
                    Spring_Green,       ///#00FF7F	
                    Spring_Green_Crayola,       ///#ECEBBD	
                    Star_Command_Blue,      ///#007BB8	
                    Steel_Blue,     ///#4682B4	
                    Steel_Pink,     ///#CC33CC	
                    Steel_Teal,     ///#5F8A8B	
                    Stil_De_Grain_Yellow,       ///#FADA5E	
                    Straw,      ///#E4D96F	
                    Sugar_Plum,     ///#914E75	
                    Sunglow,        ///#FFCC33	
                    Sunray,     ///#E3AB57	
                    Sunset,     ///#FAD6A5	
                    Super_Pink,     ///#CF6BA9	
                    Sweet_Brown,        ///#A83731	
                    Tan,        ///#D2B48C	
                    Tan_Crayola,        ///#D99A6C	
                    Tangerine,      ///#F28500	
                    Tango_Pink,     ///#E4717A	
                    Tart_Orange,        ///#FB4D46	
                    Taupe,      ///#483C32	
                    Taupe_Gray,     ///#8B8589	
                    Tea_Green,      ///#D0F0C0	
                    Tea_Rose,       ///#F88379	
                    Tea_Rose1,      ///#F4C2C2	
                    Teal,       ///#008080	
                    Teal_Blue,      ///#367588	
                    Telemagenta,        ///#CF3476	
                    Tenné_Tawny,        ///#CD5700	
                    Terra_Cotta,        ///#E2725B	
                    Thistle,        ///#D8BFD8	
                    Thulian_Pink,       ///#DE6FA1	
                    Tickle_Me_Pink,     ///#FC89AC	
                    Tiffany_Blue,       ///#0ABAB5	
                    Timberwolf,     ///#DBD7D2	
                    Titanium_Yellow,        ///#EEE600	
                    Tomato,     ///#FF6347	
                    Tropical_Rainforest,        ///#00755E	
                    True_Blue,      ///#2D68C4	
                    Trypan_Blue,        ///#1C05B3	
                    Tufts_Blue,     ///#3E8EDE	
                    Tumbleweed,     ///#DEAA88	
                    Turquoise,      ///#40E0D0	
                    Turquoise_Blue,     ///#00FFEF	
                    Turquoise_Green,        ///#A0D6B4	
                    Turtle_Green,       ///#8A9A5B	
                    Tuscan,     ///#FAD6A5	
                    Tuscan_Brown,       ///#6F4E37	
                    Tuscan_Red,     ///#7C4848	
                    Tuscan_Tan,     ///#A67B5B	
                    Tuscany,        ///#C09999	
                    Twilight_Lavender,      ///#8A496B	
                    Tyrian_Purple,      ///#66023C	
                    Ua_Blue,        ///#0033AA	
                    Ua_Red,     ///#D9004C	
                    Ultramarine,        ///#3F00FF	
                    Ultramarine_Blue,       ///#4166F5	
                    Ultra_Pink,     ///#FF6FFF	
                    Ultra_Red,      ///#FC6C85	
                    Umber,      ///#635147	
                    Unbleached_Silk,        ///#FFDDCA	
                    United_Nations_Blue,        ///#5B92E5	
                    Unmellow_Yellow,        ///#FFFF66	
                    Up_Forest_Green,        ///#014421	
                    Up_Maroon,      ///#7B1113	
                    Upsdell_Red,        ///#AE2029	
                    Uranian_Blue,       ///#AFDBF5	
                    Usafa_Blue,     ///#004F98	
                    Van_Dyke_Brown,     ///#664228	
                    Vanilla,        ///#F3E5AB	
                    Vanilla_Ice,        ///#F38FA9	
                    Vegas_Gold,     ///#C5B358	
                    Venetian_Red,       ///#C80815	
                    Verdigris,      ///#43B3AE	
                    Vermilion,      ///#E34234	
                    Vermilion1,     ///#D9381E	
                    Veronica,       ///#A020F0	
                    Violet,     ///#8F00FF	
                    Violet_Color_Wheel,     ///#7F00FF	
                    Violet_Crayola,     ///#963D7F	
                    Violet_Ryb,     ///#8601AF	
                    Violet_Web,     ///#EE82EE	
                    Violet_Blue,        ///#324AB2	
                    Violet_Blue_Crayola,        ///#766EC8	
                    Violet_Red,     ///#F75394	
                    Viridian,       ///#40826D	
                    Viridian_Green,     ///#009698	
                    Vivid_Burgundy,     ///#9F1D35	
                    Vivid_Sky_Blue,     ///#00CCFF	
                    Vivid_Tangerine,        ///#FFA089	
                    Vivid_Violet,       ///#9F00FF	
                    Volt,       ///#CEFF00	
                    Warm_Black,     ///#004242	
                    Wheat,      ///#F5DEB3	
                    White,      ///#FFFFFF	
                    Wild_Blue_Yonder,       ///#A2ADD0	
                    Wild_Orchid,        ///#D470A2	
                    Wild_Strawberry,        ///#FF43A4	
                    Wild_Watermelon,        ///#FC6C85	
                    Windsor_Tan,        ///#A75502	
                    Wine,       ///#722F37	
                    Wine_Dregs,     ///#673147	
                    Winter_Sky,     ///#FF007C	
                    Wintergreen_Dream,      ///#56887D	
                    Wisteria,       ///#C9A0DC	
                    Wood_Brown,     ///#C19A6B	
                    Xanthic,        ///#EEED09	
                    Xanadu,     ///#738678	
                    Yale_Blue,      ///#0F4D92	
                    Yellow,     ///#FFFF00	
                    Yellow_Crayola,     ///#FCE883	
                    Yellow_Munsell,     ///#EFCC00	
                    Yellow_Ncs,     ///#FFD300	
                    Yellow_Pantone,     ///#FEDF00	
                    Yellow_Process,     ///#FFEF00	
                    Yellow_Ryb,     ///#FEFE33	
                    Yellow_Green,       ///#9ACD32	
                    Yellow_Green_Crayola,       ///#C5E384	
                    Yellow_Green_Color_Wheel,       ///#30B21A	
                    Yellow_Orange,      ///#FFAE42	
                    Yellow_Orange_Color_Wheel,      ///#FF9505	
                    Yellow_Sunshine,        ///#FFF700	
                    Yinmn_Blue,     ///#2E5090	
                    Zaffre,     ///#0014A8	
                    Zomp        ///#39A78E	

                }
                public static Dictionary<ColorPalette, Color> Colors = new Dictionary<ColorPalette, Color>()
                {
                    {ColorPalette.Absolute_Zero,new Color(0f, 0.282353f, 0.7294118f, 1f)},
                    {ColorPalette.Acid_Green,new Color(0.6901961f, 0.7490196f, 0.1019608f, 1f)},
                    {ColorPalette.Aero,new Color(0.4862745f, 0.7254902f, 0.9098039f, 1f)},
                    {ColorPalette.Aero_Blue,new Color(0.7882353f, 1f, 0.8980392f, 1f)},
                    {ColorPalette.African_Violet,new Color(0.6980392f, 0.5176471f, 0.7450981f, 1f)},
                    {ColorPalette.Air_Superiority_Blue,new Color(0.4470588f, 0.627451f, 0.7568628f, 1f)},
                    {ColorPalette.Alabaster,new Color(0.9294118f, 0.9176471f, 0.8784314f, 1f)},
                    {ColorPalette.Alice_Blue,new Color(0.9411765f, 0.972549f, 1f, 1f)},
                    {ColorPalette.Alloy_Orange,new Color(0.7686275f, 0.3843137f, 0.0627451f, 1f)},
                    {ColorPalette.Almond,new Color(0.9372549f, 0.8705882f, 0.8039216f, 1f)},
                    {ColorPalette.Amaranth,new Color(0.8980392f, 0.1686275f, 0.3137255f, 1f)},
                    {ColorPalette.Amaranth_Mp,new Color(0.6235294f, 0.1686275f, 0.4078431f, 1f)},
                    {ColorPalette.Amaranth_Pink,new Color(0.945098f, 0.6117647f, 0.7333333f, 1f)},
                    {ColorPalette.Amaranth_Purple,new Color(0.6705883f, 0.1529412f, 0.3098039f, 1f)},
                    {ColorPalette.Amaranth_Red,new Color(0.827451f, 0.1294118f, 0.1764706f, 1f)},
                    {ColorPalette.Amazon,new Color(0.2313726f, 0.4784314f, 0.3411765f, 1f)},
                    {ColorPalette.Amber,new Color(1f, 0.7490196f, 0f, 1f)},
                    {ColorPalette.Amber_Sae_Ece,new Color(1f, 0.4941176f, 0f, 1f)},
                    {ColorPalette.Amethyst,new Color(0.6f, 0.4f, 0.8f, 1f)},
                    {ColorPalette.Android_Green,new Color(0.6431373f, 0.7764706f, 0.2235294f, 1f)},
                    {ColorPalette.Antique_Brass,new Color(0.8039216f, 0.5843138f, 0.4588235f, 1f)},
                    {ColorPalette.Antique_Bronze,new Color(0.4f, 0.3647059f, 0.1176471f, 1f)},
                    {ColorPalette.Antique_Fuchsia,new Color(0.5686275f, 0.3607843f, 0.5137255f, 1f)},
                    {ColorPalette.Antique_Ruby,new Color(0.5176471f, 0.1058824f, 0.1764706f, 1f)},
                    {ColorPalette.Antique_White,new Color(0.9803922f, 0.9215686f, 0.8431373f, 1f)},
                    {ColorPalette.Ao_English,new Color(0f, 0.5019608f, 0f, 1f)},
                    {ColorPalette.Apple_Green,new Color(0.5529412f, 0.7137255f, 0f, 1f)},
                    {ColorPalette.Apricot,new Color(0.9843137f, 0.8078431f, 0.6941177f, 1f)},
                    {ColorPalette.Aqua,new Color(0f, 1f, 1f, 1f)},
                    {ColorPalette.Aquamarine,new Color(0.4980392f, 1f, 0.8313726f, 1f)},
                    {ColorPalette.Arctic_Lime,new Color(0.8156863f, 1f, 0.07843138f, 1f)},
                    {ColorPalette.Army_Green,new Color(0.2941177f, 0.3254902f, 0.1254902f, 1f)},
                    {ColorPalette.Artichoke,new Color(0.5607843f, 0.5921569f, 0.4745098f, 1f)},
                    {ColorPalette.Arylide_Yellow,new Color(0.9137255f, 0.8392157f, 0.4196078f, 1f)},
                    {ColorPalette.Ash_Gray,new Color(0.6980392f, 0.7450981f, 0.7098039f, 1f)},
                    {ColorPalette.Asparagus,new Color(0.5294118f, 0.6627451f, 0.4196078f, 1f)},
                    {ColorPalette.Atomic_Tangerine,new Color(1f, 0.6f, 0.4f, 1f)},
                    {ColorPalette.Auburn,new Color(0.6470588f, 0.1647059f, 0.1647059f, 1f)},
                    {ColorPalette.Aureolin,new Color(0.9921569f, 0.9333333f, 0f, 1f)},
                    {ColorPalette.Avocado,new Color(0.3372549f, 0.509804f, 0.01176471f, 1f)},
                    {ColorPalette.Azure,new Color(0f, 0.4980392f, 1f, 1f)},
                    {ColorPalette.Azure_X11_Web_Color,new Color(0.9411765f, 1f, 1f, 1f)},
                    {ColorPalette.Baby_Blue,new Color(0.5372549f, 0.8117647f, 0.9411765f, 1f)},
                    {ColorPalette.Baby_Blue_Eyes,new Color(0.6313726f, 0.7921569f, 0.945098f, 1f)},
                    {ColorPalette.Baby_Pink,new Color(0.9568627f, 0.7607843f, 0.7607843f, 1f)},
                    {ColorPalette.Baby_Powder,new Color(0.9960784f, 0.9960784f, 0.9803922f, 1f)},
                    {ColorPalette.Baker_Miller_Pink,new Color(1f, 0.5686275f, 0.6862745f, 1f)},
                    {ColorPalette.Banana_Mania,new Color(0.9803922f, 0.9058824f, 0.7098039f, 1f)},
                    {ColorPalette.Barbie_Pink,new Color(0.854902f, 0.09411765f, 0.5176471f, 1f)},
                    {ColorPalette.Barn_Red,new Color(0.4862745f, 0.03921569f, 0.007843138f, 1f)},
                    {ColorPalette.Battleship_Grey,new Color(0.5176471f, 0.5176471f, 0.509804f, 1f)},
                    {ColorPalette.Beau_Blue,new Color(0.7372549f, 0.8313726f, 0.9019608f, 1f)},
                    {ColorPalette.Beaver,new Color(0.6235294f, 0.5058824f, 0.4392157f, 1f)},
                    {ColorPalette.Beige,new Color(0.9607843f, 0.9607843f, 0.8627451f, 1f)},
                    {ColorPalette.Bdazzled_Blue,new Color(0.1803922f, 0.345098f, 0.5803922f, 1f)},
                    {ColorPalette.Big_Dip_Oruby,new Color(0.6117647f, 0.145098f, 0.2588235f, 1f)},
                    {ColorPalette.Bisque,new Color(1f, 0.8941177f, 0.7686275f, 1f)},
                    {ColorPalette.Bistre,new Color(0.2392157f, 0.1686275f, 0.1215686f, 1f)},
                    {ColorPalette.Bistre_Brown,new Color(0.5882353f, 0.4431373f, 0.09019608f, 1f)},
                    {ColorPalette.Bitter_Lemon,new Color(0.7921569f, 0.8784314f, 0.05098039f, 1f)},
                    {ColorPalette.Bitter_Lime,new Color(0.7490196f, 1f, 0f, 1f)},
                    {ColorPalette.Bittersweet,new Color(0.9960784f, 0.4352941f, 0.3686275f, 1f)},
                    {ColorPalette.Bittersweet_Shimmer,new Color(0.7490196f, 0.3098039f, 0.3176471f, 1f)},
                    {ColorPalette.Black,new Color(0f, 0f, 0f, 1f)},
                    {ColorPalette.Black_Bean,new Color(0.2392157f, 0.04705882f, 0.007843138f, 1f)},
                    {ColorPalette.Black_Chocolate,new Color(0.1058824f, 0.09411765f, 0.06666667f, 1f)},
                    {ColorPalette.Black_Coffee,new Color(0.2313726f, 0.1843137f, 0.1843137f, 1f)},
                    {ColorPalette.Black_Coral,new Color(0.3294118f, 0.3843137f, 0.4352941f, 1f)},
                    {ColorPalette.Black_Olive,new Color(0.2313726f, 0.2352941f, 0.2117647f, 1f)},
                    {ColorPalette.Black_Shadows,new Color(0.7490196f, 0.6862745f, 0.6980392f, 1f)},
                    {ColorPalette.Blanched_Almond,new Color(1f, 0.9215686f, 0.8039216f, 1f)},
                    {ColorPalette.Blast_Off_Bronze,new Color(0.6470588f, 0.4431373f, 0.3921569f, 1f)},
                    {ColorPalette.Bleu_De_France,new Color(0.1921569f, 0.5490196f, 0.9058824f, 1f)},
                    {ColorPalette.Blizzard_Blue,new Color(0.6745098f, 0.8980392f, 0.9333333f, 1f)},
                    {ColorPalette.Blond,new Color(0.9803922f, 0.9411765f, 0.7450981f, 1f)},
                    {ColorPalette.Blood_Red,new Color(0.4f, 0f, 0f, 1f)},
                    {ColorPalette.Blue,new Color(0f, 0f, 1f, 1f)},
                    {ColorPalette.Blue_Crayola,new Color(0.1215686f, 0.4588235f, 0.9960784f, 1f)},
                    {ColorPalette.Blue_Munsell,new Color(0f, 0.5764706f, 0.6862745f, 1f)},
                    {ColorPalette.Blue_Ncs,new Color(0f, 0.5294118f, 0.7411765f, 1f)},
                    {ColorPalette.Blue_Pantone,new Color(0f, 0.09411765f, 0.6588235f, 1f)},
                    {ColorPalette.Blue_Pigment,new Color(0.2f, 0.2f, 0.6f, 1f)},
                    {ColorPalette.Blue_Ryb,new Color(0.007843138f, 0.2784314f, 0.9960784f, 1f)},
                    {ColorPalette.Blue_Bell,new Color(0.6352941f, 0.6352941f, 0.8156863f, 1f)},
                    {ColorPalette.Blue_Gray,new Color(0.4f, 0.6f, 0.8f, 1f)},
                    {ColorPalette.Blue_Green,new Color(0.05098039f, 0.5960785f, 0.7294118f, 1f)},
                    {ColorPalette.Blue_Green_Color_Wheel,new Color(0.02352941f, 0.3058824f, 0.2509804f, 1f)},
                    {ColorPalette.Blue_Jeans,new Color(0.3647059f, 0.6784314f, 0.9254902f, 1f)},
                    {ColorPalette.Blue_Sapphire,new Color(0.07058824f, 0.3803922f, 0.5019608f, 1f)},
                    {ColorPalette.Blue_Violet,new Color(0.5411765f, 0.1686275f, 0.8862745f, 1f)},
                    {ColorPalette.Blue_Violet_Crayola,new Color(0.4509804f, 0.4f, 0.7411765f, 1f)},
                    {ColorPalette.Blue_Violet_Color_Wheel,new Color(0.3019608f, 0.1019608f, 0.4980392f, 1f)},
                    {ColorPalette.Blue_Yonder,new Color(0.3137255f, 0.4470588f, 0.654902f, 1f)},
                    {ColorPalette.Bluetiful,new Color(0.2352941f, 0.4117647f, 0.9058824f, 1f)},
                    {ColorPalette.Blush,new Color(0.8705882f, 0.3647059f, 0.5137255f, 1f)},
                    {ColorPalette.Bole,new Color(0.4745098f, 0.2666667f, 0.2313726f, 1f)},
                    {ColorPalette.Bone,new Color(0.8901961f, 0.854902f, 0.7882353f, 1f)},
                    {ColorPalette.Bottle_Green,new Color(0f, 0.4156863f, 0.3058824f, 1f)},
                    {ColorPalette.Brandy,new Color(0.5294118f, 0.254902f, 0.2470588f, 1f)},
                    {ColorPalette.Brick_Red,new Color(0.7960784f, 0.254902f, 0.3294118f, 1f)},
                    {ColorPalette.Bright_Green,new Color(0.4f, 1f, 0f, 1f)},
                    {ColorPalette.Bright_Lilac,new Color(0.8470588f, 0.5686275f, 0.9372549f, 1f)},
                    {ColorPalette.Bright_Maroon,new Color(0.7647059f, 0.1294118f, 0.282353f, 1f)},
                    {ColorPalette.Bright_Navy_Blue,new Color(0.09803922f, 0.454902f, 0.8235294f, 1f)},
                    {ColorPalette.Bright_Yellow_Crayola,new Color(1f, 0.6666667f, 0.1137255f, 1f)},
                    {ColorPalette.Brilliant_Rose,new Color(1f, 0.3333333f, 0.6392157f, 1f)},
                    {ColorPalette.Brink_Pink,new Color(0.9843137f, 0.3764706f, 0.4980392f, 1f)},
                    {ColorPalette.British_Racing_Green,new Color(0f, 0.2588235f, 0.145098f, 1f)},
                    {ColorPalette.Bronze,new Color(0.8039216f, 0.4980392f, 0.1960784f, 1f)},
                    {ColorPalette.Brown,new Color(0.5333334f, 0.3294118f, 0.04313726f, 1f)},
                    {ColorPalette.Brown_Sugar,new Color(0.6862745f, 0.4313726f, 0.3019608f, 1f)},
                    {ColorPalette.Brunswick_Green,new Color(0.1058824f, 0.3019608f, 0.2431373f, 1f)},
                    {ColorPalette.Bud_Green,new Color(0.4823529f, 0.7137255f, 0.3803922f, 1f)},
                    {ColorPalette.Buff,new Color(0.9411765f, 0.8627451f, 0.509804f, 1f)},
                    {ColorPalette.Burgundy,new Color(0.5019608f, 0f, 0.1254902f, 1f)},
                    {ColorPalette.Burlywood,new Color(0.8705882f, 0.7215686f, 0.5294118f, 1f)},
                    {ColorPalette.Burnished_Brown,new Color(0.6313726f, 0.4784314f, 0.454902f, 1f)},
                    {ColorPalette.Burnt_Orange,new Color(0.8f, 0.3333333f, 0f, 1f)},
                    {ColorPalette.Burnt_Sienna,new Color(0.9137255f, 0.454902f, 0.3176471f, 1f)},
                    {ColorPalette.Burnt_Umber,new Color(0.5411765f, 0.2f, 0.1411765f, 1f)},
                    {ColorPalette.Byzantine,new Color(0.7411765f, 0.2f, 0.6431373f, 1f)},
                    {ColorPalette.Byzantium,new Color(0.4392157f, 0.1607843f, 0.3882353f, 1f)},
                    {ColorPalette.Cadet,new Color(0.3254902f, 0.4078431f, 0.4470588f, 1f)},
                    {ColorPalette.Cadet_Blue,new Color(0.372549f, 0.6196079f, 0.627451f, 1f)},
                    {ColorPalette.Cadet_Blue_Crayola,new Color(0.6627451f, 0.6980392f, 0.7647059f, 1f)},
                    {ColorPalette.Cadet_Grey,new Color(0.5686275f, 0.6392157f, 0.6901961f, 1f)},
                    {ColorPalette.Cadmium_Green,new Color(0f, 0.4196078f, 0.2352941f, 1f)},
                    {ColorPalette.Cadmium_Orange,new Color(0.9294118f, 0.5294118f, 0.1764706f, 1f)},
                    {ColorPalette.Cadmium_Red,new Color(0.8901961f, 0f, 0.1333333f, 1f)},
                    {ColorPalette.Cadmium_Yellow,new Color(1f, 0.9647059f, 0f, 1f)},
                    {ColorPalette.Café_Au_Lait,new Color(0.6509804f, 0.4823529f, 0.3568628f, 1f)},
                    {ColorPalette.Café_Noir,new Color(0.2941177f, 0.2117647f, 0.1294118f, 1f)},
                    {ColorPalette.Cambridge_Blue,new Color(0.6392157f, 0.7568628f, 0.6784314f, 1f)},
                    {ColorPalette.Camel,new Color(0.7568628f, 0.6039216f, 0.4196078f, 1f)},
                    {ColorPalette.Cameo_Pink,new Color(0.9372549f, 0.7333333f, 0.8f, 1f)},
                    {ColorPalette.Canary,new Color(1f, 1f, 0.6f, 1f)},
                    {ColorPalette.Canary_Yellow,new Color(1f, 0.9372549f, 0f, 1f)},
                    {ColorPalette.Candy_Apple_Red,new Color(1f, 0.03137255f, 0f, 1f)},
                    {ColorPalette.Candy_Pink,new Color(0.8941177f, 0.4431373f, 0.4784314f, 1f)},
                    {ColorPalette.Capri,new Color(0f, 0.7490196f, 1f, 1f)},
                    {ColorPalette.Caput_Mortuum,new Color(0.3490196f, 0.1529412f, 0.1254902f, 1f)},
                    {ColorPalette.Cardinal,new Color(0.7686275f, 0.1176471f, 0.227451f, 1f)},
                    {ColorPalette.Caribbean_Green,new Color(0f, 0.8f, 0.6f, 1f)},
                    {ColorPalette.Carmine,new Color(0.5882353f, 0f, 0.09411765f, 1f)},
                    {ColorPalette.Carmine_Mp,new Color(0.8431373f, 0f, 0.2509804f, 1f)},
                    {ColorPalette.Carnation_Pink,new Color(1f, 0.6509804f, 0.7882353f, 1f)},
                    {ColorPalette.Carnelian,new Color(0.7019608f, 0.1058824f, 0.1058824f, 1f)},
                    {ColorPalette.Carolina_Blue,new Color(0.3372549f, 0.627451f, 0.827451f, 1f)},
                    {ColorPalette.Carrot_Orange,new Color(0.9294118f, 0.5686275f, 0.1294118f, 1f)},
                    {ColorPalette.Castleton_Green,new Color(0f, 0.3372549f, 0.2470588f, 1f)},
                    {ColorPalette.Catawba,new Color(0.4392157f, 0.2117647f, 0.2588235f, 1f)},
                    {ColorPalette.Cedar_Chest,new Color(0.7882353f, 0.3529412f, 0.2862745f, 1f)},
                    {ColorPalette.Celadon,new Color(0.6745098f, 0.8823529f, 0.6862745f, 1f)},
                    {ColorPalette.Celadon_Blue,new Color(0f, 0.4823529f, 0.654902f, 1f)},
                    {ColorPalette.Celadon_Green,new Color(0.1843137f, 0.5176471f, 0.4862745f, 1f)},
                    {ColorPalette.Celeste,new Color(0.6980392f, 1f, 1f, 1f)},
                    {ColorPalette.Celtic_Blue,new Color(0.1411765f, 0.4196078f, 0.8078431f, 1f)},
                    {ColorPalette.Cerise,new Color(0.8705882f, 0.1921569f, 0.3882353f, 1f)},
                    {ColorPalette.Cerulean,new Color(0f, 0.4823529f, 0.654902f, 1f)},
                    {ColorPalette.Cerulean_Blue,new Color(0.1647059f, 0.3215686f, 0.7450981f, 1f)},
                    {ColorPalette.Cerulean_Frost,new Color(0.427451f, 0.6078432f, 0.7647059f, 1f)},
                    {ColorPalette.Cerulean_Crayola,new Color(0.1137255f, 0.6745098f, 0.8392157f, 1f)},
                    {ColorPalette.Cg_Blue,new Color(0f, 0.4784314f, 0.6470588f, 1f)},
                    {ColorPalette.Cg_Red,new Color(0.8784314f, 0.2352941f, 0.1921569f, 1f)},
                    {ColorPalette.Champagne,new Color(0.9686275f, 0.9058824f, 0.8078431f, 1f)},
                    {ColorPalette.Champagne_Pink,new Color(0.945098f, 0.8666667f, 0.8117647f, 1f)},
                    {ColorPalette.Charcoal,new Color(0.2117647f, 0.2705882f, 0.3098039f, 1f)},
                    {ColorPalette.Charleston_Green,new Color(0.1372549f, 0.1686275f, 0.1686275f, 1f)},
                    {ColorPalette.Charm_Pink,new Color(0.9019608f, 0.5607843f, 0.6745098f, 1f)},
                    {ColorPalette.Chartreuse_Traditional,new Color(0.8745098f, 1f, 0f, 1f)},
                    {ColorPalette.Chartreuse_Web,new Color(0.4980392f, 1f, 0f, 1f)},
                    {ColorPalette.Cherry_Blossom_Pink,new Color(1f, 0.7176471f, 0.772549f, 1f)},
                    {ColorPalette.Chestnut,new Color(0.5843138f, 0.2705882f, 0.2078431f, 1f)},
                    {ColorPalette.China_Pink,new Color(0.8705882f, 0.4352941f, 0.6313726f, 1f)},
                    {ColorPalette.China_Rose,new Color(0.6588235f, 0.3176471f, 0.4313726f, 1f)},
                    {ColorPalette.Chinese_Red,new Color(0.6666667f, 0.2196078f, 0.1176471f, 1f)},
                    {ColorPalette.Chinese_Violet,new Color(0.5215687f, 0.3764706f, 0.5333334f, 1f)},
                    {ColorPalette.Chinese_Yellow,new Color(1f, 0.6980392f, 0f, 1f)},
                    {ColorPalette.Chocolate_Traditional,new Color(0.4823529f, 0.2470588f, 0f, 1f)},
                    {ColorPalette.Chocolate_Web,new Color(0.8235294f, 0.4117647f, 0.1176471f, 1f)},
                    {ColorPalette.Chrome_Yellow,new Color(1f, 0.654902f, 0f, 1f)},
                    {ColorPalette.Cinereous,new Color(0.5960785f, 0.5058824f, 0.4823529f, 1f)},
                    {ColorPalette.Cinnabar,new Color(0.8901961f, 0.2588235f, 0.2039216f, 1f)},
                    {ColorPalette.Cinnamon_Satin,new Color(0.8039216f, 0.3764706f, 0.4941176f, 1f)},
                    {ColorPalette.Citrine,new Color(0.8941177f, 0.8156863f, 0.03921569f, 1f)},
                    {ColorPalette.Citron,new Color(0.6235294f, 0.6627451f, 0.1215686f, 1f)},
                    {ColorPalette.Claret,new Color(0.4980392f, 0.09019608f, 0.2039216f, 1f)},
                    {ColorPalette.Cobalt_Blue,new Color(0f, 0.2784314f, 0.6705883f, 1f)},
                    {ColorPalette.Cocoa_Brown,new Color(0.8235294f, 0.4117647f, 0.1176471f, 1f)},
                    {ColorPalette.Coffee,new Color(0.4352941f, 0.3058824f, 0.2156863f, 1f)},
                    {ColorPalette.Columbia_Blue,new Color(0.7254902f, 0.8509804f, 0.9215686f, 1f)},
                    {ColorPalette.Congo_Pink,new Color(0.972549f, 0.5137255f, 0.4745098f, 1f)},
                    {ColorPalette.Cool_Grey,new Color(0.5490196f, 0.572549f, 0.6745098f, 1f)},
                    {ColorPalette.Copper,new Color(0.7215686f, 0.4509804f, 0.2f, 1f)},
                    {ColorPalette.Copper_Crayola,new Color(0.854902f, 0.5411765f, 0.4039216f, 1f)},
                    {ColorPalette.Copper_Penny,new Color(0.6784314f, 0.4352941f, 0.4117647f, 1f)},
                    {ColorPalette.Copper_Red,new Color(0.7960784f, 0.427451f, 0.3176471f, 1f)},
                    {ColorPalette.Copper_Rose,new Color(0.6f, 0.4f, 0.4f, 1f)},
                    {ColorPalette.Coquelicot,new Color(1f, 0.2196078f, 0f, 1f)},
                    {ColorPalette.Coral,new Color(1f, 0.4980392f, 0.3137255f, 1f)},
                    {ColorPalette.Coral_Pink,new Color(0.972549f, 0.5137255f, 0.4745098f, 1f)},
                    {ColorPalette.Cordovan,new Color(0.5372549f, 0.2470588f, 0.2705882f, 1f)},
                    {ColorPalette.Corn,new Color(0.9843137f, 0.9254902f, 0.3647059f, 1f)},
                    {ColorPalette.Cornflower_Blue,new Color(0.3921569f, 0.5843138f, 0.9294118f, 1f)},
                    {ColorPalette.Cornsilk,new Color(1f, 0.972549f, 0.8627451f, 1f)},
                    {ColorPalette.Cosmic_Cobalt,new Color(0.1803922f, 0.1764706f, 0.5333334f, 1f)},
                    {ColorPalette.Cosmic_Latte,new Color(1f, 0.972549f, 0.9058824f, 1f)},
                    {ColorPalette.Coyote_Brown,new Color(0.5058824f, 0.3803922f, 0.2352941f, 1f)},
                    {ColorPalette.Cotton_Candy,new Color(1f, 0.7372549f, 0.8509804f, 1f)},
                    {ColorPalette.Cream,new Color(1f, 0.9921569f, 0.8156863f, 1f)},
                    {ColorPalette.Crimson,new Color(0.8627451f, 0.07843138f, 0.2352941f, 1f)},
                    {ColorPalette.Crimson_Ua,new Color(0.6196079f, 0.1058824f, 0.1960784f, 1f)},
                    {ColorPalette.Cultured,new Color(0.9607843f, 0.9607843f, 0.9607843f, 1f)},
                    {ColorPalette.Cyan,new Color(0f, 1f, 1f, 1f)},
                    {ColorPalette.Cyan_Process,new Color(0f, 0.7176471f, 0.9215686f, 1f)},
                    {ColorPalette.Cyber_Grape,new Color(0.345098f, 0.2588235f, 0.4862745f, 1f)},
                    {ColorPalette.Cyber_Yellow,new Color(1f, 0.827451f, 0f, 1f)},
                    {ColorPalette.Cyclamen,new Color(0.9607843f, 0.4352941f, 0.6313726f, 1f)},
                    {ColorPalette.Dark_Blue_Gray,new Color(0.4f, 0.4f, 0.6f, 1f)},
                    {ColorPalette.Dark_Brown,new Color(0.3960784f, 0.2627451f, 0.1294118f, 1f)},
                    {ColorPalette.Dark_Byzantium,new Color(0.3647059f, 0.2235294f, 0.3294118f, 1f)},
                    {ColorPalette.Dark_Cornflower_Blue,new Color(0.1490196f, 0.2588235f, 0.5450981f, 1f)},
                    {ColorPalette.Dark_Cyan,new Color(0f, 0.5450981f, 0.5450981f, 1f)},
                    {ColorPalette.Dark_Electric_Blue,new Color(0.3254902f, 0.4078431f, 0.4705882f, 1f)},
                    {ColorPalette.Dark_Goldenrod,new Color(0.7215686f, 0.5254902f, 0.04313726f, 1f)},
                    {ColorPalette.Dark_Green,new Color(0.003921569f, 0.1960784f, 0.1254902f, 1f)},
                    {ColorPalette.Dark_Green_X11,new Color(0f, 0.3921569f, 0f, 1f)},
                    {ColorPalette.Dark_Jungle_Green,new Color(0.1019608f, 0.1411765f, 0.1294118f, 1f)},
                    {ColorPalette.Dark_Khaki,new Color(0.7411765f, 0.7176471f, 0.4196078f, 1f)},
                    {ColorPalette.Dark_Lava,new Color(0.282353f, 0.2352941f, 0.1960784f, 1f)},
                    {ColorPalette.Dark_Liver,new Color(0.3254902f, 0.2941177f, 0.3098039f, 1f)},
                    {ColorPalette.Dark_Liver_Horses,new Color(0.3294118f, 0.2392157f, 0.2156863f, 1f)},
                    {ColorPalette.Dark_Magenta,new Color(0.5450981f, 0f, 0.5450981f, 1f)},
                    {ColorPalette.Dark_Moss_Green,new Color(0.2901961f, 0.3647059f, 0.1372549f, 1f)},
                    {ColorPalette.Dark_Olive_Green,new Color(0.3333333f, 0.4196078f, 0.1843137f, 1f)},
                    {ColorPalette.Dark_Orange,new Color(1f, 0.5490196f, 0f, 1f)},
                    {ColorPalette.Dark_Orchid,new Color(0.6f, 0.1960784f, 0.8f, 1f)},
                    {ColorPalette.Dark_Pastel_Green,new Color(0.01176471f, 0.7529412f, 0.2352941f, 1f)},
                    {ColorPalette.Dark_Purple,new Color(0.1882353f, 0.09803922f, 0.2039216f, 1f)},
                    {ColorPalette.Dark_Red,new Color(0.5450981f, 0f, 0f, 1f)},
                    {ColorPalette.Dark_Salmon,new Color(0.9137255f, 0.5882353f, 0.4784314f, 1f)},
                    {ColorPalette.Dark_Sea_Green,new Color(0.5607843f, 0.7372549f, 0.5607843f, 1f)},
                    {ColorPalette.Dark_Sienna,new Color(0.2352941f, 0.07843138f, 0.07843138f, 1f)},
                    {ColorPalette.Dark_Sky_Blue,new Color(0.5490196f, 0.7450981f, 0.8392157f, 1f)},
                    {ColorPalette.Dark_Slate_Blue,new Color(0.282353f, 0.2392157f, 0.5450981f, 1f)},
                    {ColorPalette.Dark_Slate_Gray,new Color(0.1843137f, 0.3098039f, 0.3098039f, 1f)},
                    {ColorPalette.Dark_Spring_Green,new Color(0.09019608f, 0.4470588f, 0.2705882f, 1f)},
                    {ColorPalette.Dark_Turquoise,new Color(0f, 0.8078431f, 0.8196079f, 1f)},
                    {ColorPalette.Dark_Violet,new Color(0.5803922f, 0f, 0.827451f, 1f)},
                    {ColorPalette.Dartmouth_Green,new Color(0f, 0.4392157f, 0.2352941f, 1f)},
                    {ColorPalette.Davys_Grey,new Color(0.3333333f, 0.3333333f, 0.3333333f, 1f)},
                    {ColorPalette.Deep_Cerise,new Color(0.854902f, 0.1960784f, 0.5294118f, 1f)},
                    {ColorPalette.Deep_Champagne,new Color(0.9803922f, 0.8392157f, 0.6470588f, 1f)},
                    {ColorPalette.Deep_Chestnut,new Color(0.7254902f, 0.3058824f, 0.282353f, 1f)},
                    {ColorPalette.Deep_Jungle_Green,new Color(0f, 0.2941177f, 0.2862745f, 1f)},
                    {ColorPalette.Deep_Pink,new Color(1f, 0.07843138f, 0.5764706f, 1f)},
                    {ColorPalette.Deep_Saffron,new Color(1f, 0.6f, 0.2f, 1f)},
                    {ColorPalette.Deep_Sky_Blue,new Color(0f, 0.7490196f, 1f, 1f)},
                    {ColorPalette.Deep_Space_Sparkle,new Color(0.2901961f, 0.3921569f, 0.4235294f, 1f)},
                    {ColorPalette.Deep_Taupe,new Color(0.4941176f, 0.3686275f, 0.3764706f, 1f)},
                    {ColorPalette.Denim,new Color(0.08235294f, 0.3764706f, 0.7411765f, 1f)},
                    {ColorPalette.Denim_Blue,new Color(0.1333333f, 0.2627451f, 0.7137255f, 1f)},
                    {ColorPalette.Desert,new Color(0.7568628f, 0.6039216f, 0.4196078f, 1f)},
                    {ColorPalette.Desert_Sand,new Color(0.9294118f, 0.7882353f, 0.6862745f, 1f)},
                    {ColorPalette.Dim_Gray,new Color(0.4117647f, 0.4117647f, 0.4117647f, 1f)},
                    {ColorPalette.Dodger_Blue,new Color(0.1176471f, 0.5647059f, 1f, 1f)},
                    {ColorPalette.Dogwood_Rose,new Color(0.8431373f, 0.09411765f, 0.4078431f, 1f)},
                    {ColorPalette.Drab,new Color(0.5882353f, 0.4431373f, 0.09019608f, 1f)},
                    {ColorPalette.Duke_Blue,new Color(0f, 0f, 0.6117647f, 1f)},
                    {ColorPalette.Dutch_White,new Color(0.9372549f, 0.8745098f, 0.7333333f, 1f)},
                    {ColorPalette.Earth_Yellow,new Color(0.8823529f, 0.6627451f, 0.372549f, 1f)},
                    {ColorPalette.Ebony,new Color(0.3333333f, 0.3647059f, 0.3137255f, 1f)},
                    {ColorPalette.Ecru,new Color(0.7607843f, 0.6980392f, 0.5019608f, 1f)},
                    {ColorPalette.Eerie_Black,new Color(0.1058824f, 0.1058824f, 0.1058824f, 1f)},
                    {ColorPalette.Eggplant,new Color(0.3803922f, 0.2509804f, 0.3176471f, 1f)},
                    {ColorPalette.Eggshell,new Color(0.9411765f, 0.9176471f, 0.8392157f, 1f)},
                    {ColorPalette.Egyptian_Blue,new Color(0.0627451f, 0.2039216f, 0.6509804f, 1f)},
                    {ColorPalette.Electric_Blue,new Color(0.4901961f, 0.9764706f, 1f, 1f)},
                    {ColorPalette.Electric_Green,new Color(0f, 1f, 0f, 1f)},
                    {ColorPalette.Electric_Indigo,new Color(0.4352941f, 0f, 1f, 1f)},
                    {ColorPalette.Electric_Lime,new Color(0.8f, 1f, 0f, 1f)},
                    {ColorPalette.Electric_Purple,new Color(0.7490196f, 0f, 1f, 1f)},
                    {ColorPalette.Electric_Violet,new Color(0.5607843f, 0f, 1f, 1f)},
                    {ColorPalette.Emerald,new Color(0.3137255f, 0.7843137f, 0.4705882f, 1f)},
                    {ColorPalette.Eminence,new Color(0.4235294f, 0.1882353f, 0.509804f, 1f)},
                    {ColorPalette.English_Green,new Color(0.1058824f, 0.3019608f, 0.2431373f, 1f)},
                    {ColorPalette.English_Lavender,new Color(0.7058824f, 0.5137255f, 0.5843138f, 1f)},
                    {ColorPalette.English_Red,new Color(0.6705883f, 0.2941177f, 0.3215686f, 1f)},
                    {ColorPalette.English_Vermillion,new Color(0.8f, 0.2784314f, 0.2941177f, 1f)},
                    {ColorPalette.English_Violet,new Color(0.3372549f, 0.2352941f, 0.3607843f, 1f)},
                    {ColorPalette.Erin,new Color(0f, 1f, 0.2509804f, 1f)},
                    {ColorPalette.Eton_Blue,new Color(0.5882353f, 0.7843137f, 0.6352941f, 1f)},
                    {ColorPalette.Fallow,new Color(0.7568628f, 0.6039216f, 0.4196078f, 1f)},
                    {ColorPalette.Falu_Red,new Color(0.5019608f, 0.09411765f, 0.09411765f, 1f)},
                    {ColorPalette.Fandango,new Color(0.7098039f, 0.2f, 0.5372549f, 1f)},
                    {ColorPalette.Fandango_Pink,new Color(0.8705882f, 0.3215686f, 0.5215687f, 1f)},
                    {ColorPalette.Fashion_Fuchsia,new Color(0.9568627f, 0f, 0.6313726f, 1f)},
                    {ColorPalette.Fawn,new Color(0.8980392f, 0.6666667f, 0.4392157f, 1f)},
                    {ColorPalette.Feldgrau,new Color(0.3019608f, 0.3647059f, 0.3254902f, 1f)},
                    {ColorPalette.Fern_Green,new Color(0.3098039f, 0.4745098f, 0.2588235f, 1f)},
                    {ColorPalette.Field_Drab,new Color(0.4235294f, 0.3294118f, 0.1176471f, 1f)},
                    {ColorPalette.Fiery_Rose,new Color(1f, 0.3294118f, 0.4392157f, 1f)},
                    {ColorPalette.Firebrick,new Color(0.6980392f, 0.1333333f, 0.1333333f, 1f)},
                    {ColorPalette.Fire_Engine_Red,new Color(0.8078431f, 0.1254902f, 0.1607843f, 1f)},
                    {ColorPalette.Fire_Opal,new Color(0.9137255f, 0.3607843f, 0.2941177f, 1f)},
                    {ColorPalette.Flame,new Color(0.8862745f, 0.345098f, 0.1333333f, 1f)},
                    {ColorPalette.Flax,new Color(0.9333333f, 0.8627451f, 0.509804f, 1f)},
                    {ColorPalette.Flickr_Blue,new Color(0f, 0.3882353f, 0.8627451f, 1f)},
                    {ColorPalette.Flickr_Pink,new Color(0.9843137f, 0f, 0.5058824f, 1f)},
                    {ColorPalette.Flirt,new Color(0.6352941f, 0f, 0.427451f, 1f)},
                    {ColorPalette.Floral_White,new Color(1f, 0.9803922f, 0.9411765f, 1f)},
                    {ColorPalette.Fluorescent_Blue,new Color(0.08235294f, 0.9568627f, 0.9333333f, 1f)},
                    {ColorPalette.Forest_Green_Crayola,new Color(0.372549f, 0.654902f, 0.4666667f, 1f)},
                    {ColorPalette.Forest_Green_Traditional,new Color(0.003921569f, 0.2666667f, 0.1294118f, 1f)},
                    {ColorPalette.Forest_Green_Web,new Color(0.1333333f, 0.5450981f, 0.1333333f, 1f)},
                    {ColorPalette.French_Beige,new Color(0.6509804f, 0.4823529f, 0.3568628f, 1f)},
                    {ColorPalette.French_Bistre,new Color(0.5215687f, 0.427451f, 0.3019608f, 1f)},
                    {ColorPalette.French_Blue,new Color(0f, 0.4470588f, 0.7333333f, 1f)},
                    {ColorPalette.French_Fuchsia,new Color(0.9921569f, 0.2470588f, 0.572549f, 1f)},
                    {ColorPalette.French_Lilac,new Color(0.5254902f, 0.3764706f, 0.5568628f, 1f)},
                    {ColorPalette.French_Lime,new Color(0.6196079f, 0.9921569f, 0.2196078f, 1f)},
                    {ColorPalette.French_Mauve,new Color(0.8313726f, 0.4509804f, 0.8313726f, 1f)},
                    {ColorPalette.French_Pink,new Color(0.9921569f, 0.4235294f, 0.6196079f, 1f)},
                    {ColorPalette.French_Raspberry,new Color(0.7803922f, 0.172549f, 0.282353f, 1f)},
                    {ColorPalette.French_Rose,new Color(0.9647059f, 0.2901961f, 0.5411765f, 1f)},
                    {ColorPalette.French_Sky_Blue,new Color(0.4666667f, 0.7098039f, 0.9960784f, 1f)},
                    {ColorPalette.French_Violet,new Color(0.5333334f, 0.02352941f, 0.8078431f, 1f)},
                    {ColorPalette.Frostbite,new Color(0.9137255f, 0.2117647f, 0.654902f, 1f)},
                    {ColorPalette.Fuchsia,new Color(1f, 0f, 1f, 1f)},
                    {ColorPalette.Fuchsia_Crayola,new Color(0.7568628f, 0.3294118f, 0.7568628f, 1f)},
                    {ColorPalette.Fuchsia_Purple,new Color(0.8f, 0.2235294f, 0.4823529f, 1f)},
                    {ColorPalette.Fuchsia_Rose,new Color(0.7803922f, 0.2627451f, 0.4588235f, 1f)},
                    {ColorPalette.Fulvous,new Color(0.8941177f, 0.5176471f, 0f, 1f)},
                    {ColorPalette.Fuzzy_Wuzzy,new Color(0.5294118f, 0.2588235f, 0.1215686f, 1f)},
                    {ColorPalette.Gainsboro,new Color(0.8627451f, 0.8627451f, 0.8627451f, 1f)},
                    {ColorPalette.Gamboge,new Color(0.8941177f, 0.6078432f, 0.05882353f, 1f)},
                    {ColorPalette.Generic_Viridian,new Color(0f, 0.4980392f, 0.4f, 1f)},
                    {ColorPalette.Ghost_White,new Color(0.972549f, 0.972549f, 1f, 1f)},
                    {ColorPalette.Glaucous,new Color(0.3764706f, 0.509804f, 0.7137255f, 1f)},
                    {ColorPalette.Glossy_Grape,new Color(0.6705883f, 0.572549f, 0.7019608f, 1f)},
                    {ColorPalette.Go_Green,new Color(0f, 0.6705883f, 0.4f, 1f)},
                    {ColorPalette.Gold,new Color(0.6470588f, 0.4862745f, 0f, 1f)},
                    {ColorPalette.Gold_Metallic,new Color(0.8313726f, 0.6862745f, 0.2156863f, 1f)},
                    {ColorPalette.Gold_Web_Golden,new Color(1f, 0.8431373f, 0f, 1f)},
                    {ColorPalette.Gold_Crayola,new Color(0.9019608f, 0.7450981f, 0.5411765f, 1f)},
                    {ColorPalette.Gold_Fusion,new Color(0.5215687f, 0.4588235f, 0.3058824f, 1f)},
                    {ColorPalette.Golden_Brown,new Color(0.6f, 0.3960784f, 0.08235294f, 1f)},
                    {ColorPalette.Golden_Poppy,new Color(0.9882353f, 0.7607843f, 0f, 1f)},
                    {ColorPalette.Golden_Yellow,new Color(1f, 0.8745098f, 0f, 1f)},
                    {ColorPalette.Goldenrod,new Color(0.854902f, 0.6470588f, 0.1254902f, 1f)},
                    {ColorPalette.Granite_Gray,new Color(0.4039216f, 0.4039216f, 0.4039216f, 1f)},
                    {ColorPalette.Granny_Smith_Apple,new Color(0.6588235f, 0.8941177f, 0.627451f, 1f)},
                    {ColorPalette.Gray_Web,new Color(0.5019608f, 0.5019608f, 0.5019608f, 1f)},
                    {ColorPalette.Gray_X11_Gray,new Color(0.7450981f, 0.7450981f, 0.7450981f, 1f)},
                    {ColorPalette.Green,new Color(0f, 1f, 0f, 1f)},
                    {ColorPalette.Green_Crayola,new Color(0.1098039f, 0.6745098f, 0.4705882f, 1f)},
                    {ColorPalette.Green_Web,new Color(0f, 0.5019608f, 0f, 1f)},
                    {ColorPalette.Green_Munsell,new Color(0f, 0.6588235f, 0.4666667f, 1f)},
                    {ColorPalette.Green_Ncs,new Color(0f, 0.6235294f, 0.4196078f, 1f)},
                    {ColorPalette.Green_Pantone,new Color(0f, 0.6784314f, 0.2627451f, 1f)},
                    {ColorPalette.Green_Pigment,new Color(0f, 0.6470588f, 0.3137255f, 1f)},
                    {ColorPalette.Green_Ryb,new Color(0.4f, 0.6901961f, 0.1960784f, 1f)},
                    {ColorPalette.Green_Blue,new Color(0.06666667f, 0.3921569f, 0.7058824f, 1f)},
                    {ColorPalette.Green_Blue_Crayola,new Color(0.1568628f, 0.5294118f, 0.7843137f, 1f)},
                    {ColorPalette.Green_Cyan,new Color(0f, 0.6f, 0.4f, 1f)},
                    {ColorPalette.Green_Lizard,new Color(0.654902f, 0.9568627f, 0.1960784f, 1f)},
                    {ColorPalette.Green_Sheen,new Color(0.4313726f, 0.682353f, 0.6313726f, 1f)},
                    {ColorPalette.Green_Yellow,new Color(0.6784314f, 1f, 0.1843137f, 1f)},
                    {ColorPalette.Green_Yellow_Crayola,new Color(0.9411765f, 0.9098039f, 0.5686275f, 1f)},
                    {ColorPalette.Grullo,new Color(0.6627451f, 0.6039216f, 0.5254902f, 1f)},
                    {ColorPalette.Gunmetal,new Color(0.1647059f, 0.2039216f, 0.2235294f, 1f)},
                    {ColorPalette.Han_Blue,new Color(0.2666667f, 0.4235294f, 0.8117647f, 1f)},
                    {ColorPalette.Han_Purple,new Color(0.3215686f, 0.09411765f, 0.9803922f, 1f)},
                    {ColorPalette.Hansa_Yellow,new Color(0.9137255f, 0.8392157f, 0.4196078f, 1f)},
                    {ColorPalette.Harlequin,new Color(0.2470588f, 1f, 0f, 1f)},
                    {ColorPalette.Harvest_Gold,new Color(0.854902f, 0.5686275f, 0f, 1f)},
                    {ColorPalette.Heat_Wave,new Color(1f, 0.4784314f, 0f, 1f)},
                    {ColorPalette.Heliotrope,new Color(0.8745098f, 0.4509804f, 1f, 1f)},
                    {ColorPalette.Heliotrope_Gray,new Color(0.6666667f, 0.5960785f, 0.6627451f, 1f)},
                    {ColorPalette.Hollywood_Cerise,new Color(0.9568627f, 0f, 0.6313726f, 1f)},
                    {ColorPalette.Honeydew,new Color(0.9411765f, 1f, 0.9411765f, 1f)},
                    {ColorPalette.Honolulu_Blue,new Color(0f, 0.427451f, 0.6901961f, 1f)},
                    {ColorPalette.Hookers_Green,new Color(0.2862745f, 0.4745098f, 0.4196078f, 1f)},
                    {ColorPalette.Hot_Magenta,new Color(1f, 0.1137255f, 0.8078431f, 1f)},
                    {ColorPalette.Hot_Pink,new Color(1f, 0.4117647f, 0.7058824f, 1f)},
                    {ColorPalette.Hunter_Green,new Color(0.2078431f, 0.3686275f, 0.2313726f, 1f)},
                    {ColorPalette.Iceberg,new Color(0.4431373f, 0.6509804f, 0.8235294f, 1f)},
                    {ColorPalette.Icterine,new Color(0.9882353f, 0.9686275f, 0.3686275f, 1f)},
                    {ColorPalette.Illuminating_Emerald,new Color(0.1921569f, 0.5686275f, 0.4666667f, 1f)},
                    {ColorPalette.Imperial_Red,new Color(0.9294118f, 0.1607843f, 0.2235294f, 1f)},
                    {ColorPalette.Inchworm,new Color(0.6980392f, 0.9254902f, 0.3647059f, 1f)},
                    {ColorPalette.Independence,new Color(0.2980392f, 0.3176471f, 0.427451f, 1f)},
                    {ColorPalette.India_Green,new Color(0.07450981f, 0.5333334f, 0.03137255f, 1f)},
                    {ColorPalette.Indian_Red,new Color(0.8039216f, 0.3607843f, 0.3607843f, 1f)},
                    {ColorPalette.Indian_Yellow,new Color(0.8901961f, 0.6588235f, 0.3411765f, 1f)},
                    {ColorPalette.Indigo,new Color(0.2941177f, 0f, 0.509804f, 1f)},
                    {ColorPalette.Indigo_Dye,new Color(0f, 0.254902f, 0.4156863f, 1f)},
                    {ColorPalette.International_Klein_Blue,new Color(0f, 0.1843137f, 0.654902f, 1f)},
                    {ColorPalette.International_Orange_Aerospace,new Color(1f, 0.3098039f, 0f, 1f)},
                    {ColorPalette.International_Orange_Engineering,new Color(0.7294118f, 0.08627451f, 0.04705882f, 1f)},
                    {ColorPalette.International_Orange_Golden_Gate_Bridge,new Color(0.7529412f, 0.2117647f, 0.172549f, 1f)},
                    {ColorPalette.Iris,new Color(0.3529412f, 0.3098039f, 0.8117647f, 1f)},
                    {ColorPalette.Irresistible,new Color(0.7019608f, 0.2666667f, 0.4235294f, 1f)},
                    {ColorPalette.Isabelline,new Color(0.9568627f, 0.9411765f, 0.9254902f, 1f)},
                    {ColorPalette.Italian_Sky_Blue,new Color(0.6980392f, 1f, 1f, 1f)},
                    {ColorPalette.Ivory,new Color(1f, 1f, 0.9411765f, 1f)},
                    {ColorPalette.Jade,new Color(0f, 0.6588235f, 0.4196078f, 1f)},
                    {ColorPalette.Jasmine,new Color(0.972549f, 0.8705882f, 0.4941176f, 1f)},
                    {ColorPalette.Jazzberry_Jam,new Color(0.6470588f, 0.04313726f, 0.3686275f, 1f)},
                    {ColorPalette.Jet,new Color(0.2039216f, 0.2039216f, 0.2039216f, 1f)},
                    {ColorPalette.Jonquil,new Color(0.9568627f, 0.7921569f, 0.08627451f, 1f)},
                    {ColorPalette.June_Bud,new Color(0.7411765f, 0.854902f, 0.3411765f, 1f)},
                    {ColorPalette.Jungle_Green,new Color(0.1607843f, 0.6705883f, 0.5294118f, 1f)},
                    {ColorPalette.Kelly_Green,new Color(0.2980392f, 0.7333333f, 0.09019608f, 1f)},
                    {ColorPalette.Keppel,new Color(0.227451f, 0.6901961f, 0.6196079f, 1f)},
                    {ColorPalette.Key_Lime,new Color(0.9098039f, 0.9568627f, 0.5490196f, 1f)},
                    {ColorPalette.Khaki_Web,new Color(0.7647059f, 0.6901961f, 0.5686275f, 1f)},
                    {ColorPalette.Khaki_X11_Light_Khaki,new Color(0.9411765f, 0.9019608f, 0.5490196f, 1f)},
                    {ColorPalette.Kobe,new Color(0.5333334f, 0.1764706f, 0.09019608f, 1f)},
                    {ColorPalette.Kobi,new Color(0.9058824f, 0.6235294f, 0.7686275f, 1f)},
                    {ColorPalette.Kobicha,new Color(0.4196078f, 0.2666667f, 0.1372549f, 1f)},
                    {ColorPalette.Kombu_Green,new Color(0.2078431f, 0.2588235f, 0.1882353f, 1f)},
                    {ColorPalette.Ksu_Purple,new Color(0.3176471f, 0.1568628f, 0.5333334f, 1f)},
                    {ColorPalette.Languid_Lavender,new Color(0.8392157f, 0.7921569f, 0.8666667f, 1f)},
                    {ColorPalette.Lapis_Lazuli,new Color(0.1490196f, 0.3803922f, 0.6117647f, 1f)},
                    {ColorPalette.Laser_Lemon,new Color(1f, 1f, 0.4f, 1f)},
                    {ColorPalette.Laurel_Green,new Color(0.6627451f, 0.7294118f, 0.6156863f, 1f)},
                    {ColorPalette.Lava,new Color(0.8117647f, 0.0627451f, 0.1254902f, 1f)},
                    {ColorPalette.Lavender_Floral,new Color(0.7098039f, 0.4941176f, 0.8627451f, 1f)},
                    {ColorPalette.Lavender_Web,new Color(0.9019608f, 0.9019608f, 0.9803922f, 1f)},
                    {ColorPalette.Lavender_Blue,new Color(0.8f, 0.8f, 1f, 1f)},
                    {ColorPalette.Lavender_Blush,new Color(1f, 0.9411765f, 0.9607843f, 1f)},
                    {ColorPalette.Lavender_Gray,new Color(0.7686275f, 0.7647059f, 0.8156863f, 1f)},
                    {ColorPalette.Lawn_Green,new Color(0.4862745f, 0.9882353f, 0f, 1f)},
                    {ColorPalette.Lemon,new Color(1f, 0.9686275f, 0f, 1f)},
                    {ColorPalette.Lemon_Chiffon,new Color(1f, 0.9803922f, 0.8039216f, 1f)},
                    {ColorPalette.Lemon_Curry,new Color(0.8f, 0.627451f, 0.1137255f, 1f)},
                    {ColorPalette.Lemon_Glacier,new Color(0.9921569f, 1f, 0f, 1f)},
                    {ColorPalette.Lemon_Meringue,new Color(0.9647059f, 0.9176471f, 0.7450981f, 1f)},
                    {ColorPalette.Lemon_Yellow,new Color(1f, 0.9568627f, 0.3098039f, 1f)},
                    {ColorPalette.Lemon_Yellow_Crayola,new Color(1f, 1f, 0.6235294f, 1f)},
                    {ColorPalette.Liberty,new Color(0.3294118f, 0.3529412f, 0.654902f, 1f)},
                    {ColorPalette.Light_Blue,new Color(0.6784314f, 0.8470588f, 0.9019608f, 1f)},
                    {ColorPalette.Light_Coral,new Color(0.9411765f, 0.5019608f, 0.5019608f, 1f)},
                    {ColorPalette.Light_Cornflower_Blue,new Color(0.5764706f, 0.8f, 0.9176471f, 1f)},
                    {ColorPalette.Light_Cyan,new Color(0.8784314f, 1f, 1f, 1f)},
                    {ColorPalette.Light_French_Beige,new Color(0.7843137f, 0.6784314f, 0.4980392f, 1f)},
                    {ColorPalette.Light_Goldenrod_Yellow,new Color(0.9803922f, 0.9803922f, 0.8235294f, 1f)},
                    {ColorPalette.Light_Gray,new Color(0.827451f, 0.827451f, 0.827451f, 1f)},
                    {ColorPalette.Light_Green,new Color(0.5647059f, 0.9333333f, 0.5647059f, 1f)},
                    {ColorPalette.Light_Orange,new Color(0.9960784f, 0.8470588f, 0.6941177f, 1f)},
                    {ColorPalette.Light_Periwinkle,new Color(0.772549f, 0.7960784f, 0.8823529f, 1f)},
                    {ColorPalette.Light_Pink,new Color(1f, 0.7137255f, 0.7568628f, 1f)},
                    {ColorPalette.Light_Salmon,new Color(1f, 0.627451f, 0.4784314f, 1f)},
                    {ColorPalette.Light_Sea_Green,new Color(0.1254902f, 0.6980392f, 0.6666667f, 1f)},
                    {ColorPalette.Light_Sky_Blue,new Color(0.5294118f, 0.8078431f, 0.9803922f, 1f)},
                    {ColorPalette.Light_Slate_Gray,new Color(0.4666667f, 0.5333334f, 0.6f, 1f)},
                    {ColorPalette.Light_Steel_Blue,new Color(0.6901961f, 0.7686275f, 0.8705882f, 1f)},
                    {ColorPalette.Light_Yellow,new Color(1f, 1f, 0.8784314f, 1f)},
                    {ColorPalette.Lilac,new Color(0.7843137f, 0.6352941f, 0.7843137f, 1f)},
                    {ColorPalette.Lilac_Luster,new Color(0.682353f, 0.5960785f, 0.6666667f, 1f)},
                    {ColorPalette.Lime_Color_Wheel,new Color(0.7490196f, 1f, 0f, 1f)},
                    {ColorPalette.Lime_Web_X11_Green,new Color(0f, 1f, 0f, 1f)},
                    {ColorPalette.Lime_Green,new Color(0.1960784f, 0.8039216f, 0.1960784f, 1f)},
                    {ColorPalette.Lincoln_Green,new Color(0.09803922f, 0.3490196f, 0.01960784f, 1f)},
                    {ColorPalette.Linen,new Color(0.9803922f, 0.9411765f, 0.9019608f, 1f)},
                    {ColorPalette.Lion,new Color(0.7568628f, 0.6039216f, 0.4196078f, 1f)},
                    {ColorPalette.Liseran_Purple,new Color(0.8705882f, 0.4352941f, 0.6313726f, 1f)},
                    {ColorPalette.Little_Boy_Blue,new Color(0.4235294f, 0.627451f, 0.8627451f, 1f)},
                    {ColorPalette.Liver,new Color(0.4039216f, 0.2980392f, 0.2784314f, 1f)},
                    {ColorPalette.Liver_Dogs,new Color(0.7215686f, 0.427451f, 0.1607843f, 1f)},
                    {ColorPalette.Liver_Organ,new Color(0.4235294f, 0.1803922f, 0.1215686f, 1f)},
                    {ColorPalette.Liver_Chestnut,new Color(0.5960785f, 0.454902f, 0.3372549f, 1f)},
                    {ColorPalette.Livid,new Color(0.4f, 0.6f, 0.8f, 1f)},
                    {ColorPalette.Macaroni_And_Cheese,new Color(1f, 0.7411765f, 0.5333334f, 1f)},
                    {ColorPalette.Madder_Lake,new Color(0.8f, 0.2f, 0.2117647f, 1f)},
                    {ColorPalette.Magenta,new Color(1f, 0f, 1f, 1f)},
                    {ColorPalette.Magenta_Crayola,new Color(0.9647059f, 0.3254902f, 0.6509804f, 1f)},
                    {ColorPalette.Magenta_Dye,new Color(0.7921569f, 0.1215686f, 0.4823529f, 1f)},
                    {ColorPalette.Magenta_Pantone,new Color(0.8156863f, 0.254902f, 0.4941176f, 1f)},
                    {ColorPalette.Magenta_Process,new Color(1f, 0f, 0.5647059f, 1f)},
                    {ColorPalette.Magenta_Haze,new Color(0.6235294f, 0.2705882f, 0.4627451f, 1f)},
                    {ColorPalette.Magic_Mint,new Color(0.6666667f, 0.9411765f, 0.8196079f, 1f)},
                    {ColorPalette.Magnolia,new Color(0.9490196f, 0.9098039f, 0.8431373f, 1f)},
                    {ColorPalette.Mahogany,new Color(0.7529412f, 0.2509804f, 0f, 1f)},
                    {ColorPalette.Maize,new Color(0.9843137f, 0.9254902f, 0.3647059f, 1f)},
                    {ColorPalette.Maize_Crayola,new Color(0.9490196f, 0.7764706f, 0.2862745f, 1f)},
                    {ColorPalette.Majorelle_Blue,new Color(0.3764706f, 0.3137255f, 0.8627451f, 1f)},
                    {ColorPalette.Malachite,new Color(0.04313726f, 0.854902f, 0.3176471f, 1f)},
                    {ColorPalette.Manatee,new Color(0.5921569f, 0.6039216f, 0.6666667f, 1f)},
                    {ColorPalette.Mandarin,new Color(0.9529412f, 0.4784314f, 0.282353f, 1f)},
                    {ColorPalette.Mango,new Color(0.9921569f, 0.7450981f, 0.007843138f, 1f)},
                    {ColorPalette.Mango_Tango,new Color(1f, 0.509804f, 0.2627451f, 1f)},
                    {ColorPalette.Mantis,new Color(0.454902f, 0.7647059f, 0.3960784f, 1f)},
                    {ColorPalette.Mardi_Gras,new Color(0.5333334f, 0f, 0.5215687f, 1f)},
                    {ColorPalette.Marigold,new Color(0.9176471f, 0.6352941f, 0.1294118f, 1f)},
                    {ColorPalette.Maroon_Crayola,new Color(0.7647059f, 0.1294118f, 0.282353f, 1f)},
                    {ColorPalette.Maroon_Web,new Color(0.5019608f, 0f, 0f, 1f)},
                    {ColorPalette.Maroon_X11,new Color(0.6901961f, 0.1882353f, 0.3764706f, 1f)},
                    {ColorPalette.Mauve,new Color(0.8784314f, 0.6901961f, 1f, 1f)},
                    {ColorPalette.Mauve_Taupe,new Color(0.5686275f, 0.372549f, 0.427451f, 1f)},
                    {ColorPalette.Mauvelous,new Color(0.9372549f, 0.5960785f, 0.6666667f, 1f)},
                    {ColorPalette.Maximum_Blue,new Color(0.2784314f, 0.6705883f, 0.8f, 1f)},
                    {ColorPalette.Maximum_Blue_Green,new Color(0.1882353f, 0.7490196f, 0.7490196f, 1f)},
                    {ColorPalette.Maximum_Blue_Purple,new Color(0.6745098f, 0.6745098f, 0.9019608f, 1f)},
                    {ColorPalette.Maximum_Green,new Color(0.3686275f, 0.5490196f, 0.1921569f, 1f)},
                    {ColorPalette.Maximum_Green_Yellow,new Color(0.8509804f, 0.9019608f, 0.3137255f, 1f)},
                    {ColorPalette.Maximum_Purple,new Color(0.4509804f, 0.2f, 0.5019608f, 1f)},
                    {ColorPalette.Maximum_Red,new Color(0.8509804f, 0.1294118f, 0.1294118f, 1f)},
                    {ColorPalette.Maximum_Red_Purple,new Color(0.6509804f, 0.227451f, 0.4745098f, 1f)},
                    {ColorPalette.Maximum_Yellow,new Color(0.9803922f, 0.9803922f, 0.2156863f, 1f)},
                    {ColorPalette.Maximum_Yellow_Red,new Color(0.9490196f, 0.7294118f, 0.2862745f, 1f)},
                    {ColorPalette.May_Green,new Color(0.2980392f, 0.5686275f, 0.254902f, 1f)},
                    {ColorPalette.Maya_Blue,new Color(0.4509804f, 0.7607843f, 0.9843137f, 1f)},
                    {ColorPalette.Medium_Aquamarine,new Color(0.4f, 0.8666667f, 0.6666667f, 1f)},
                    {ColorPalette.Medium_Blue,new Color(0f, 0f, 0.8039216f, 1f)},
                    {ColorPalette.Medium_Candy_Apple_Red,new Color(0.8862745f, 0.02352941f, 0.172549f, 1f)},
                    {ColorPalette.Medium_Carmine,new Color(0.6862745f, 0.2509804f, 0.2078431f, 1f)},
                    {ColorPalette.Medium_Champagne,new Color(0.9529412f, 0.8980392f, 0.6705883f, 1f)},
                    {ColorPalette.Medium_Orchid,new Color(0.7294118f, 0.3333333f, 0.827451f, 1f)},
                    {ColorPalette.Medium_Purple,new Color(0.5764706f, 0.4392157f, 0.8588235f, 1f)},
                    {ColorPalette.Medium_Sea_Green,new Color(0.2352941f, 0.7019608f, 0.4431373f, 1f)},
                    {ColorPalette.Medium_Slate_Blue,new Color(0.4823529f, 0.4078431f, 0.9333333f, 1f)},
                    {ColorPalette.Medium_Spring_Green,new Color(0f, 0.9803922f, 0.6039216f, 1f)},
                    {ColorPalette.Medium_Turquoise,new Color(0.282353f, 0.8196079f, 0.8f, 1f)},
                    {ColorPalette.Medium_Violet_Red,new Color(0.7803922f, 0.08235294f, 0.5215687f, 1f)},
                    {ColorPalette.Mellow_Apricot,new Color(0.972549f, 0.7215686f, 0.4705882f, 1f)},
                    {ColorPalette.Mellow_Yellow,new Color(0.972549f, 0.8705882f, 0.4941176f, 1f)},
                    {ColorPalette.Melon,new Color(0.9960784f, 0.7294118f, 0.6784314f, 1f)},
                    {ColorPalette.Metallic_Gold,new Color(0.827451f, 0.6862745f, 0.2156863f, 1f)},
                    {ColorPalette.Metallic_Seaweed,new Color(0.03921569f, 0.4941176f, 0.5490196f, 1f)},
                    {ColorPalette.Metallic_Sunburst,new Color(0.6117647f, 0.4862745f, 0.2196078f, 1f)},
                    {ColorPalette.Mexican_Pink,new Color(0.8941177f, 0f, 0.4862745f, 1f)},
                    {ColorPalette.Middle_Blue,new Color(0.4941176f, 0.8313726f, 0.9019608f, 1f)},
                    {ColorPalette.Middle_Blue_Green,new Color(0.5529412f, 0.8509804f, 0.8f, 1f)},
                    {ColorPalette.Middle_Blue_Purple,new Color(0.5450981f, 0.4470588f, 0.7450981f, 1f)},
                    {ColorPalette.Middle_Grey,new Color(0.5450981f, 0.5254902f, 0.5019608f, 1f)},
                    {ColorPalette.Middle_Green,new Color(0.3019608f, 0.5490196f, 0.3411765f, 1f)},
                    {ColorPalette.Middle_Green_Yellow,new Color(0.6745098f, 0.7490196f, 0.3764706f, 1f)},
                    {ColorPalette.Middle_Purple,new Color(0.8509804f, 0.509804f, 0.7098039f, 1f)},
                    {ColorPalette.Middle_Red,new Color(0.8980392f, 0.5568628f, 0.4509804f, 1f)},
                    {ColorPalette.Middle_Red_Purple,new Color(0.6470588f, 0.3254902f, 0.3254902f, 1f)},
                    {ColorPalette.Middle_Yellow,new Color(1f, 0.9215686f, 0f, 1f)},
                    {ColorPalette.Middle_Yellow_Red,new Color(0.9254902f, 0.6941177f, 0.4627451f, 1f)},
                    {ColorPalette.Midnight,new Color(0.4392157f, 0.1490196f, 0.4392157f, 1f)},
                    {ColorPalette.Midnight_Blue,new Color(0.09803922f, 0.09803922f, 0.4392157f, 1f)},
                    {ColorPalette.Midnight_Green_Eagle_Green,new Color(0f, 0.2862745f, 0.3254902f, 1f)},
                    {ColorPalette.Mikado_Yellow,new Color(1f, 0.7686275f, 0.04705882f, 1f)},
                    {ColorPalette.Mimi_Pink,new Color(1f, 0.854902f, 0.9137255f, 1f)},
                    {ColorPalette.Mindaro,new Color(0.8901961f, 0.9764706f, 0.5333334f, 1f)},
                    {ColorPalette.Ming,new Color(0.2117647f, 0.454902f, 0.4901961f, 1f)},
                    {ColorPalette.Minion_Yellow,new Color(0.9607843f, 0.8784314f, 0.3137255f, 1f)},
                    {ColorPalette.Mint,new Color(0.2431373f, 0.7058824f, 0.5372549f, 1f)},
                    {ColorPalette.Mint_Cream,new Color(0.9607843f, 1f, 0.9803922f, 1f)},
                    {ColorPalette.Mint_Green,new Color(0.5960785f, 1f, 0.5960785f, 1f)},
                    {ColorPalette.Misty_Moss,new Color(0.7333333f, 0.7058824f, 0.4666667f, 1f)},
                    {ColorPalette.Misty_Rose,new Color(1f, 0.8941177f, 0.8823529f, 1f)},
                    {ColorPalette.Mode_Beige,new Color(0.5882353f, 0.4431373f, 0.09019608f, 1f)},
                    {ColorPalette.Morning_Blue,new Color(0.5529412f, 0.6392157f, 0.6f, 1f)},
                    {ColorPalette.Moss_Green,new Color(0.5411765f, 0.6039216f, 0.3568628f, 1f)},
                    {ColorPalette.Mountain_Meadow,new Color(0.1882353f, 0.7294118f, 0.5607843f, 1f)},
                    {ColorPalette.Mountbatten_Pink,new Color(0.6f, 0.4784314f, 0.5529412f, 1f)},
                    {ColorPalette.Msu_Green,new Color(0.09411765f, 0.2705882f, 0.2313726f, 1f)},
                    {ColorPalette.Mulberry,new Color(0.772549f, 0.2941177f, 0.5490196f, 1f)},
                    {ColorPalette.Mulberry_Crayola,new Color(0.7843137f, 0.3137255f, 0.6078432f, 1f)},
                    {ColorPalette.Mustard,new Color(1f, 0.8588235f, 0.345098f, 1f)},
                    {ColorPalette.Myrtle_Green,new Color(0.1921569f, 0.4705882f, 0.4509804f, 1f)},
                    {ColorPalette.Mystic,new Color(0.8392157f, 0.3215686f, 0.509804f, 1f)},
                    {ColorPalette.Mystic_Maroon,new Color(0.6784314f, 0.2627451f, 0.4745098f, 1f)},
                    {ColorPalette.Nadeshiko_Pink,new Color(0.9647059f, 0.6784314f, 0.7764706f, 1f)},
                    {ColorPalette.Naples_Yellow,new Color(0.9803922f, 0.854902f, 0.3686275f, 1f)},
                    {ColorPalette.Navajo_White,new Color(1f, 0.8705882f, 0.6784314f, 1f)},
                    {ColorPalette.Navy_Blue,new Color(0f, 0f, 0.5019608f, 1f)},
                    {ColorPalette.Navy_Blue_Crayola,new Color(0.09803922f, 0.454902f, 0.8235294f, 1f)},
                    {ColorPalette.Neon_Blue,new Color(0.2745098f, 0.4f, 1f, 1f)},
                    {ColorPalette.Neon_Green,new Color(0.2235294f, 1f, 0.07843138f, 1f)},
                    {ColorPalette.New_York_Pink,new Color(0.8431373f, 0.5137255f, 0.4980392f, 1f)},
                    {ColorPalette.Nickel,new Color(0.4470588f, 0.454902f, 0.4470588f, 1f)},
                    {ColorPalette.Non_Photo_Blue,new Color(0.6431373f, 0.8666667f, 0.9294118f, 1f)},
                    {ColorPalette.Nyanza,new Color(0.9137255f, 1f, 0.8588235f, 1f)},
                    {ColorPalette.Ocean_Blue,new Color(0.3098039f, 0.2588235f, 0.7098039f, 1f)},
                    {ColorPalette.Ocean_Green,new Color(0.282353f, 0.7490196f, 0.5686275f, 1f)},
                    {ColorPalette.Ochre,new Color(0.8f, 0.4666667f, 0.1333333f, 1f)},
                    {ColorPalette.Old_Burgundy,new Color(0.2627451f, 0.1882353f, 0.1803922f, 1f)},
                    {ColorPalette.Old_Gold,new Color(0.8117647f, 0.7098039f, 0.2313726f, 1f)},
                    {ColorPalette.Old_Lace,new Color(0.9921569f, 0.9607843f, 0.9019608f, 1f)},
                    {ColorPalette.Old_Lavender,new Color(0.4745098f, 0.4078431f, 0.4705882f, 1f)},
                    {ColorPalette.Old_Mauve,new Color(0.4039216f, 0.1921569f, 0.2784314f, 1f)},
                    {ColorPalette.Old_Rose,new Color(0.7529412f, 0.5019608f, 0.5058824f, 1f)},
                    {ColorPalette.Old_Silver,new Color(0.5176471f, 0.5176471f, 0.509804f, 1f)},
                    {ColorPalette.Olive,new Color(0.5019608f, 0.5019608f, 0f, 1f)},
                    {ColorPalette.Olive_Drab3,new Color(0.4196078f, 0.5568628f, 0.1372549f, 1f)},
                    {ColorPalette.Olive_Drab7,new Color(0.2352941f, 0.2039216f, 0.1215686f, 1f)},
                    {ColorPalette.Olive_Green,new Color(0.7098039f, 0.7019608f, 0.3607843f, 1f)},
                    {ColorPalette.Olivine,new Color(0.6039216f, 0.7254902f, 0.4509804f, 1f)},
                    {ColorPalette.Onyx,new Color(0.2078431f, 0.2196078f, 0.2235294f, 1f)},
                    {ColorPalette.Opal,new Color(0.6588235f, 0.7647059f, 0.7372549f, 1f)},
                    {ColorPalette.Opera_Mauve,new Color(0.7176471f, 0.5176471f, 0.654902f, 1f)},
                    {ColorPalette.Orange,new Color(1f, 0.4980392f, 0f, 1f)},
                    {ColorPalette.Orange_Crayola,new Color(1f, 0.4588235f, 0.2196078f, 1f)},
                    {ColorPalette.Orange_Pantone,new Color(1f, 0.345098f, 0f, 1f)},
                    {ColorPalette.Orange_Web,new Color(1f, 0.6470588f, 0f, 1f)},
                    {ColorPalette.Orange_Peel,new Color(1f, 0.6235294f, 0f, 1f)},
                    {ColorPalette.Orange_Red,new Color(1f, 0.4078431f, 0.1215686f, 1f)},
                    {ColorPalette.Orange_Red_Crayola,new Color(1f, 0.3254902f, 0.2862745f, 1f)},
                    {ColorPalette.Orange_Soda,new Color(0.9803922f, 0.3568628f, 0.2392157f, 1f)},
                    {ColorPalette.Orange_Yellow,new Color(0.9607843f, 0.7411765f, 0.1215686f, 1f)},
                    {ColorPalette.Orange_Yellow_Crayola,new Color(0.972549f, 0.8352941f, 0.4078431f, 1f)},
                    {ColorPalette.Orchid,new Color(0.854902f, 0.4392157f, 0.8392157f, 1f)},
                    {ColorPalette.Orchid_Pink,new Color(0.9490196f, 0.7411765f, 0.8039216f, 1f)},
                    {ColorPalette.Orchid_Crayola,new Color(0.8862745f, 0.6117647f, 0.8235294f, 1f)},
                    {ColorPalette.Outer_Space_Crayola,new Color(0.1764706f, 0.2196078f, 0.227451f, 1f)},
                    {ColorPalette.Outrageous_Orange,new Color(1f, 0.4313726f, 0.2901961f, 1f)},
                    {ColorPalette.Oxblood,new Color(0.5019608f, 0f, 0.1254902f, 1f)},
                    {ColorPalette.Oxford_Blue,new Color(0f, 0.1294118f, 0.2784314f, 1f)},
                    {ColorPalette.Ou_Crimson_Red,new Color(0.5176471f, 0.08627451f, 0.09019608f, 1f)},
                    {ColorPalette.Pacific_Blue,new Color(0.1098039f, 0.6627451f, 0.7882353f, 1f)},
                    {ColorPalette.Pakistan_Green,new Color(0f, 0.4f, 0f, 1f)},
                    {ColorPalette.Palatinate_Purple,new Color(0.4078431f, 0.1568628f, 0.3764706f, 1f)},
                    {ColorPalette.Pale_Aqua,new Color(0.7372549f, 0.8313726f, 0.9019608f, 1f)},
                    {ColorPalette.Pale_Cerulean,new Color(0.6078432f, 0.7686275f, 0.8862745f, 1f)},
                    {ColorPalette.Pale_Pink,new Color(0.9803922f, 0.854902f, 0.8666667f, 1f)},
                    {ColorPalette.Pale_Purple_Pantone,new Color(0.9803922f, 0.9019608f, 0.9803922f, 1f)},
                    {ColorPalette.Pale_Silver,new Color(0.7882353f, 0.7529412f, 0.7333333f, 1f)},
                    {ColorPalette.Pale_Spring_Bud,new Color(0.9254902f, 0.9215686f, 0.7411765f, 1f)},
                    {ColorPalette.Pansy_Purple,new Color(0.4705882f, 0.09411765f, 0.2901961f, 1f)},
                    {ColorPalette.Paolo_Veronese_Green,new Color(0f, 0.6078432f, 0.4901961f, 1f)},
                    {ColorPalette.Papaya_Whip,new Color(1f, 0.9372549f, 0.8352941f, 1f)},
                    {ColorPalette.Paradise_Pink,new Color(0.9019608f, 0.2431373f, 0.3843137f, 1f)},
                    {ColorPalette.Paris_Green,new Color(0.3137255f, 0.7843137f, 0.4705882f, 1f)},
                    {ColorPalette.Pastel_Pink,new Color(0.8705882f, 0.6470588f, 0.6431373f, 1f)},
                    {ColorPalette.Patriarch,new Color(0.5019608f, 0f, 0.5019608f, 1f)},
                    {ColorPalette.Paynes_Grey,new Color(0.3254902f, 0.4078431f, 0.4705882f, 1f)},
                    {ColorPalette.Peach,new Color(1f, 0.8980392f, 0.7058824f, 1f)},
                    {ColorPalette.Peach_Crayola,new Color(1f, 0.7960784f, 0.6431373f, 1f)},
                    {ColorPalette.Peach_Puff,new Color(1f, 0.854902f, 0.7254902f, 1f)},
                    {ColorPalette.Pear,new Color(0.8196079f, 0.8862745f, 0.1921569f, 1f)},
                    {ColorPalette.Pearly_Purple,new Color(0.7176471f, 0.4078431f, 0.6352941f, 1f)},
                    {ColorPalette.Periwinkle,new Color(0.8f, 0.8f, 1f, 1f)},
                    {ColorPalette.Periwinkle_Crayola,new Color(0.7647059f, 0.8039216f, 0.9019608f, 1f)},
                    {ColorPalette.Permanent_Geranium_Lake,new Color(0.8823529f, 0.172549f, 0.172549f, 1f)},
                    {ColorPalette.Persian_Blue,new Color(0.1098039f, 0.2235294f, 0.7333333f, 1f)},
                    {ColorPalette.Persian_Green,new Color(0f, 0.6509804f, 0.5764706f, 1f)},
                    {ColorPalette.Persian_Indigo,new Color(0.1960784f, 0.07058824f, 0.4784314f, 1f)},
                    {ColorPalette.Persian_Orange,new Color(0.8509804f, 0.5647059f, 0.345098f, 1f)},
                    {ColorPalette.Persian_Pink,new Color(0.9686275f, 0.4980392f, 0.7450981f, 1f)},
                    {ColorPalette.Persian_Plum,new Color(0.4392157f, 0.1098039f, 0.1098039f, 1f)},
                    {ColorPalette.Persian_Red,new Color(0.8f, 0.2f, 0.2f, 1f)},
                    {ColorPalette.Persian_Rose,new Color(0.9960784f, 0.1568628f, 0.6352941f, 1f)},
                    {ColorPalette.Persimmon,new Color(0.9254902f, 0.345098f, 0f, 1f)},
                    {ColorPalette.Pewter_Blue,new Color(0.5450981f, 0.6588235f, 0.7176471f, 1f)},
                    {ColorPalette.Phlox,new Color(0.8745098f, 0f, 1f, 1f)},
                    {ColorPalette.Phthalo_Blue,new Color(0f, 0.05882353f, 0.5372549f, 1f)},
                    {ColorPalette.Phthalo_Green,new Color(0.07058824f, 0.2078431f, 0.1411765f, 1f)},
                    {ColorPalette.Picotee_Blue,new Color(0.1803922f, 0.1529412f, 0.5294118f, 1f)},
                    {ColorPalette.Pictorial_Carmine,new Color(0.7647059f, 0.04313726f, 0.3058824f, 1f)},
                    {ColorPalette.Piggy_Pink,new Color(0.9921569f, 0.8666667f, 0.9019608f, 1f)},
                    {ColorPalette.Pine_Green,new Color(0.003921569f, 0.4745098f, 0.4352941f, 1f)},
                    {ColorPalette.Pine_Tree,new Color(0.1647059f, 0.1843137f, 0.1372549f, 1f)},
                    {ColorPalette.Pink,new Color(1f, 0.7529412f, 0.7960784f, 1f)},
                    {ColorPalette.Pink_Pantone,new Color(0.8431373f, 0.282353f, 0.5803922f, 1f)},
                    {ColorPalette.Pink_Flamingo,new Color(0.9882353f, 0.454902f, 0.9921569f, 1f)},
                    {ColorPalette.Pink_Lace,new Color(1f, 0.8666667f, 0.9568627f, 1f)},
                    {ColorPalette.Pink_Lavender,new Color(0.8470588f, 0.6980392f, 0.8196079f, 1f)},
                    {ColorPalette.Pink_Sherbet,new Color(0.9686275f, 0.5607843f, 0.654902f, 1f)},
                    {ColorPalette.Pistachio,new Color(0.5764706f, 0.772549f, 0.4470588f, 1f)},
                    {ColorPalette.Platinum,new Color(0.8980392f, 0.8941177f, 0.8862745f, 1f)},
                    {ColorPalette.Plum,new Color(0.5568628f, 0.2705882f, 0.5215687f, 1f)},
                    {ColorPalette.Plum_Web,new Color(0.8666667f, 0.627451f, 0.8666667f, 1f)},
                    {ColorPalette.Plump_Purple,new Color(0.3490196f, 0.2745098f, 0.6980392f, 1f)},
                    {ColorPalette.Polished_Pine,new Color(0.3647059f, 0.6431373f, 0.5764706f, 1f)},
                    {ColorPalette.Pomp_And_Power,new Color(0.5254902f, 0.3764706f, 0.5568628f, 1f)},
                    {ColorPalette.Popstar,new Color(0.7450981f, 0.3098039f, 0.3843137f, 1f)},
                    {ColorPalette.Portland_Orange,new Color(1f, 0.3529412f, 0.2117647f, 1f)},
                    {ColorPalette.Powder_Blue,new Color(0.6901961f, 0.8784314f, 0.9019608f, 1f)},
                    {ColorPalette.Princeton_Orange,new Color(0.9607843f, 0.5019608f, 0.145098f, 1f)},
                    {ColorPalette.Prune,new Color(0.4392157f, 0.1098039f, 0.1098039f, 1f)},
                    {ColorPalette.Prussian_Blue,new Color(0f, 0.1921569f, 0.3254902f, 1f)},
                    {ColorPalette.Psychedelic_Purple,new Color(0.8745098f, 0f, 1f, 1f)},
                    {ColorPalette.Puce,new Color(0.8f, 0.5333334f, 0.6f, 1f)},
                    {ColorPalette.Pullman_Brown_Ups_Brown,new Color(0.3921569f, 0.254902f, 0.09019608f, 1f)},
                    {ColorPalette.Pumpkin,new Color(1f, 0.4588235f, 0.09411765f, 1f)},
                    {ColorPalette.Purple,new Color(0.4156863f, 0.05098039f, 0.6784314f, 1f)},
                    {ColorPalette.Purple_Web,new Color(0.5019608f, 0f, 0.5019608f, 1f)},
                    {ColorPalette.Purple_Munsell,new Color(0.6235294f, 0f, 0.772549f, 1f)},
                    {ColorPalette.Purple_X11,new Color(0.627451f, 0.1254902f, 0.9411765f, 1f)},
                    {ColorPalette.Purple_Mountain_Majesty,new Color(0.5882353f, 0.4705882f, 0.7137255f, 1f)},
                    {ColorPalette.Purple_Navy,new Color(0.3058824f, 0.3176471f, 0.5019608f, 1f)},
                    {ColorPalette.Purple_Pizzazz,new Color(0.9960784f, 0.3058824f, 0.854902f, 1f)},
                    {ColorPalette.Purple_Plum,new Color(0.6117647f, 0.3176471f, 0.7137255f, 1f)},
                    {ColorPalette.Purpureus,new Color(0.6039216f, 0.3058824f, 0.682353f, 1f)},
                    {ColorPalette.Queen_Blue,new Color(0.2627451f, 0.4196078f, 0.5843138f, 1f)},
                    {ColorPalette.Queen_Pink,new Color(0.9098039f, 0.8f, 0.8431373f, 1f)},
                    {ColorPalette.Quick_Silver,new Color(0.6509804f, 0.6509804f, 0.6509804f, 1f)},
                    {ColorPalette.Quinacridone_Magenta,new Color(0.5568628f, 0.227451f, 0.3490196f, 1f)},
                    {ColorPalette.Radical_Red,new Color(1f, 0.2078431f, 0.3686275f, 1f)},
                    {ColorPalette.Raisin_Black,new Color(0.1411765f, 0.1294118f, 0.1411765f, 1f)},
                    {ColorPalette.Rajah,new Color(0.9843137f, 0.6705883f, 0.3764706f, 1f)},
                    {ColorPalette.Raspberry,new Color(0.8901961f, 0.04313726f, 0.3647059f, 1f)},
                    {ColorPalette.Raspberry_Glace,new Color(0.5686275f, 0.372549f, 0.427451f, 1f)},
                    {ColorPalette.Raspberry_Rose,new Color(0.7019608f, 0.2666667f, 0.4235294f, 1f)},
                    {ColorPalette.Raw_Sienna,new Color(0.8392157f, 0.5411765f, 0.3490196f, 1f)},
                    {ColorPalette.Raw_Umber,new Color(0.509804f, 0.4f, 0.2666667f, 1f)},
                    {ColorPalette.Razzle_Dazzle_Rose,new Color(1f, 0.2f, 0.8f, 1f)},
                    {ColorPalette.Razzmatazz,new Color(0.8901961f, 0.145098f, 0.4196078f, 1f)},
                    {ColorPalette.Razzmic_Berry,new Color(0.5529412f, 0.3058824f, 0.5215687f, 1f)},
                    {ColorPalette.Rebecca_Purple,new Color(0.4f, 0.2f, 0.6f, 1f)},
                    {ColorPalette.Red,new Color(1f, 0f, 0f, 1f)},
                    {ColorPalette.Red_Crayola,new Color(0.9333333f, 0.1254902f, 0.3019608f, 1f)},
                    {ColorPalette.Red_Munsell,new Color(0.9490196f, 0f, 0.2352941f, 1f)},
                    {ColorPalette.Red_Ncs,new Color(0.7686275f, 0.007843138f, 0.2f, 1f)},
                    {ColorPalette.Red_Pantone,new Color(0.9294118f, 0.1607843f, 0.2235294f, 1f)},
                    {ColorPalette.Red_Pigment,new Color(0.9294118f, 0.1098039f, 0.1411765f, 1f)},
                    {ColorPalette.Red_Ryb,new Color(0.9960784f, 0.1529412f, 0.07058824f, 1f)},
                    {ColorPalette.Red_Orange,new Color(1f, 0.3254902f, 0.2862745f, 1f)},
                    {ColorPalette.Red_Orange_Crayola,new Color(1f, 0.4078431f, 0.1215686f, 1f)},
                    {ColorPalette.Red_Orange_Color_Wheel,new Color(1f, 0.2705882f, 0f, 1f)},
                    {ColorPalette.Red_Purple,new Color(0.8941177f, 0f, 0.4705882f, 1f)},
                    {ColorPalette.Red_Salsa,new Color(0.9921569f, 0.227451f, 0.2901961f, 1f)},
                    {ColorPalette.Red_Violet,new Color(0.7803922f, 0.08235294f, 0.5215687f, 1f)},
                    {ColorPalette.Red_Violet_Crayola,new Color(0.7529412f, 0.2666667f, 0.5607843f, 1f)},
                    {ColorPalette.Red_Violet_Color_Wheel,new Color(0.572549f, 0.1686275f, 0.2431373f, 1f)},
                    {ColorPalette.Redwood,new Color(0.6431373f, 0.3529412f, 0.3215686f, 1f)},
                    {ColorPalette.Resolution_Blue,new Color(0f, 0.1372549f, 0.5294118f, 1f)},
                    {ColorPalette.Rhythm,new Color(0.4666667f, 0.4627451f, 0.5882353f, 1f)},
                    {ColorPalette.Rich_Black,new Color(0f, 0.2509804f, 0.2509804f, 1f)},
                    {ColorPalette.Rich_Black_Fogra29,new Color(0.003921569f, 0.04313726f, 0.07450981f, 1f)},
                    {ColorPalette.Rich_Black_Fogra39,new Color(0.003921569f, 0.007843138f, 0.01176471f, 1f)},
                    {ColorPalette.Rifle_Green,new Color(0.2666667f, 0.2980392f, 0.2196078f, 1f)},
                    {ColorPalette.Robin_Egg_Blue,new Color(0f, 0.8f, 0.8f, 1f)},
                    {ColorPalette.Rocket_Metallic,new Color(0.5411765f, 0.4980392f, 0.5019608f, 1f)},
                    {ColorPalette.Roman_Silver,new Color(0.5137255f, 0.5372549f, 0.5882353f, 1f)},
                    {ColorPalette.Rose,new Color(1f, 0f, 0.4980392f, 1f)},
                    {ColorPalette.Rose_Bonbon,new Color(0.9764706f, 0.2588235f, 0.6196079f, 1f)},
                    {ColorPalette.Rose_Dust,new Color(0.6196079f, 0.3686275f, 0.4352941f, 1f)},
                    {ColorPalette.Rose_Ebony,new Color(0.4039216f, 0.282353f, 0.2745098f, 1f)},
                    {ColorPalette.Rose_Madder,new Color(0.8901961f, 0.1490196f, 0.2117647f, 1f)},
                    {ColorPalette.Rose_Pink,new Color(1f, 0.4f, 0.8f, 1f)},
                    {ColorPalette.Rose_Quartz,new Color(0.6666667f, 0.5960785f, 0.6627451f, 1f)},
                    {ColorPalette.Rose_Red,new Color(0.7607843f, 0.1176471f, 0.3372549f, 1f)},
                    {ColorPalette.Rose_Taupe,new Color(0.5647059f, 0.3647059f, 0.3647059f, 1f)},
                    {ColorPalette.Rose_Vale,new Color(0.6705883f, 0.3058824f, 0.3215686f, 1f)},
                    {ColorPalette.Rosewood,new Color(0.3960784f, 0f, 0.04313726f, 1f)},
                    {ColorPalette.Rosso_Corsa,new Color(0.8313726f, 0f, 0f, 1f)},
                    {ColorPalette.Rosy_Brown,new Color(0.7372549f, 0.5607843f, 0.5607843f, 1f)},
                    {ColorPalette.Royal_Blue_Dark,new Color(0f, 0.1372549f, 0.4f, 1f)},
                    {ColorPalette.Royal_Blue_Light,new Color(0.254902f, 0.4117647f, 0.8823529f, 1f)},
                    {ColorPalette.Royal_Purple,new Color(0.4705882f, 0.3176471f, 0.6627451f, 1f)},
                    {ColorPalette.Royal_Yellow,new Color(0.9803922f, 0.854902f, 0.3686275f, 1f)},
                    {ColorPalette.Ruber,new Color(0.8078431f, 0.2745098f, 0.4627451f, 1f)},
                    {ColorPalette.Rubine_Red,new Color(0.8196079f, 0f, 0.3372549f, 1f)},
                    {ColorPalette.Ruby,new Color(0.8784314f, 0.06666667f, 0.372549f, 1f)},
                    {ColorPalette.Ruby_Red,new Color(0.6078432f, 0.06666667f, 0.1176471f, 1f)},
                    {ColorPalette.Rufous,new Color(0.6588235f, 0.1098039f, 0.02745098f, 1f)},
                    {ColorPalette.Russet,new Color(0.5019608f, 0.2745098f, 0.1058824f, 1f)},
                    {ColorPalette.Russian_Green,new Color(0.4039216f, 0.572549f, 0.4039216f, 1f)},
                    {ColorPalette.Russian_Violet,new Color(0.1960784f, 0.09019608f, 0.3019608f, 1f)},
                    {ColorPalette.Rust,new Color(0.7176471f, 0.254902f, 0.05490196f, 1f)},
                    {ColorPalette.Rusty_Red,new Color(0.854902f, 0.172549f, 0.2627451f, 1f)},
                    {ColorPalette.Sacramento_State_Green,new Color(0.01568628f, 0.2235294f, 0.1529412f, 1f)},
                    {ColorPalette.Saddle_Brown,new Color(0.5450981f, 0.2705882f, 0.07450981f, 1f)},
                    {ColorPalette.Safety_Orange,new Color(1f, 0.4705882f, 0f, 1f)},
                    {ColorPalette.Safety_Orange_Blaze_Orange,new Color(1f, 0.4039216f, 0f, 1f)},
                    {ColorPalette.Safety_Yellow,new Color(0.9333333f, 0.8235294f, 0.007843138f, 1f)},
                    {ColorPalette.Saffron,new Color(0.9568627f, 0.7686275f, 0.1882353f, 1f)},
                    {ColorPalette.Sage,new Color(0.7372549f, 0.7215686f, 0.5411765f, 1f)},
                    {ColorPalette.St_Patricks_Blue,new Color(0.1372549f, 0.1607843f, 0.4784314f, 1f)},
                    {ColorPalette.Salmon,new Color(0.9803922f, 0.5019608f, 0.4470588f, 1f)},
                    {ColorPalette.Salmon_Pink,new Color(1f, 0.5686275f, 0.6431373f, 1f)},
                    {ColorPalette.Sand,new Color(0.7607843f, 0.6980392f, 0.5019608f, 1f)},
                    {ColorPalette.Sand_Dune,new Color(0.5882353f, 0.4431373f, 0.09019608f, 1f)},
                    {ColorPalette.Sandy_Brown,new Color(0.9568627f, 0.6431373f, 0.3764706f, 1f)},
                    {ColorPalette.Sap_Green,new Color(0.3137255f, 0.4901961f, 0.1647059f, 1f)},
                    {ColorPalette.Sapphire,new Color(0.05882353f, 0.3215686f, 0.7294118f, 1f)},
                    {ColorPalette.Sapphire_Blue,new Color(0f, 0.4039216f, 0.6470588f, 1f)},
                    {ColorPalette.Sapphire_Crayola,new Color(0f, 0.4039216f, 0.6470588f, 1f)},
                    {ColorPalette.Satin_Sheen_Gold,new Color(0.7960784f, 0.6313726f, 0.2078431f, 1f)},
                    {ColorPalette.Scarlet,new Color(1f, 0.1411765f, 0f, 1f)},
                    {ColorPalette.Schauss_Pink,new Color(1f, 0.5686275f, 0.6862745f, 1f)},
                    {ColorPalette.School_Bus_Yellow,new Color(1f, 0.8470588f, 0f, 1f)},
                    {ColorPalette.Screamin_Green,new Color(0.4f, 1f, 0.4f, 1f)},
                    {ColorPalette.Sea_Green,new Color(0.1803922f, 0.5450981f, 0.3411765f, 1f)},
                    {ColorPalette.Sea_Green_Crayola,new Color(0f, 1f, 0.8039216f, 1f)},
                    {ColorPalette.Seal_Brown,new Color(0.3490196f, 0.1490196f, 0.04313726f, 1f)},
                    {ColorPalette.Seashell,new Color(1f, 0.9607843f, 0.9333333f, 1f)},
                    {ColorPalette.Selective_Yellow,new Color(1f, 0.7294118f, 0f, 1f)},
                    {ColorPalette.Sepia,new Color(0.4392157f, 0.2588235f, 0.07843138f, 1f)},
                    {ColorPalette.Shadow,new Color(0.5411765f, 0.4745098f, 0.3647059f, 1f)},
                    {ColorPalette.Shadow_Blue,new Color(0.4666667f, 0.5450981f, 0.6470588f, 1f)},
                    {ColorPalette.Shamrock_Green,new Color(0f, 0.6196079f, 0.3764706f, 1f)},
                    {ColorPalette.Sheen_Green,new Color(0.5607843f, 0.8313726f, 0f, 1f)},
                    {ColorPalette.Shimmering_Blush,new Color(0.8509804f, 0.5254902f, 0.5843138f, 1f)},
                    {ColorPalette.Shiny_Shamrock,new Color(0.372549f, 0.654902f, 0.4705882f, 1f)},
                    {ColorPalette.Shocking_Pink,new Color(0.9882353f, 0.05882353f, 0.7529412f, 1f)},
                    {ColorPalette.Shocking_Pink_Crayola,new Color(1f, 0.4352941f, 1f, 1f)},
                    {ColorPalette.Sienna,new Color(0.5333334f, 0.1764706f, 0.09019608f, 1f)},
                    {ColorPalette.Silver,new Color(0.7529412f, 0.7529412f, 0.7529412f, 1f)},
                    {ColorPalette.Silver_Crayola,new Color(0.7882353f, 0.7529412f, 0.7333333f, 1f)},
                    {ColorPalette.Silver_Metallic,new Color(0.6666667f, 0.6627451f, 0.6784314f, 1f)},
                    {ColorPalette.Silver_Chalice,new Color(0.6745098f, 0.6745098f, 0.6745098f, 1f)},
                    {ColorPalette.Silver_Pink,new Color(0.7686275f, 0.682353f, 0.6784314f, 1f)},
                    {ColorPalette.Silver_Sand,new Color(0.7490196f, 0.7568628f, 0.7607843f, 1f)},
                    {ColorPalette.Sinopia,new Color(0.7960784f, 0.254902f, 0.04313726f, 1f)},
                    {ColorPalette.Sizzling_Red,new Color(1f, 0.2196078f, 0.3333333f, 1f)},
                    {ColorPalette.Sizzling_Sunrise,new Color(1f, 0.8588235f, 0f, 1f)},
                    {ColorPalette.Skobeloff,new Color(0f, 0.454902f, 0.454902f, 1f)},
                    {ColorPalette.Sky_Blue,new Color(0.5294118f, 0.8078431f, 0.9215686f, 1f)},
                    {ColorPalette.Sky_Blue_Crayola,new Color(0.4627451f, 0.8431373f, 0.9176471f, 1f)},
                    {ColorPalette.Sky_Magenta,new Color(0.8117647f, 0.4431373f, 0.6862745f, 1f)},
                    {ColorPalette.Slate_Blue,new Color(0.4156863f, 0.3529412f, 0.8039216f, 1f)},
                    {ColorPalette.Slate_Gray,new Color(0.4392157f, 0.5019608f, 0.5647059f, 1f)},
                    {ColorPalette.Slimy_Green,new Color(0.1607843f, 0.5882353f, 0.09019608f, 1f)},
                    {ColorPalette.Smitten,new Color(0.7843137f, 0.254902f, 0.5254902f, 1f)},
                    {ColorPalette.Smoky_Black,new Color(0.0627451f, 0.04705882f, 0.03137255f, 1f)},
                    {ColorPalette.Snow,new Color(1f, 0.9803922f, 0.9803922f, 1f)},
                    {ColorPalette.Solid_Pink,new Color(0.5372549f, 0.2196078f, 0.2627451f, 1f)},
                    {ColorPalette.Sonic_Silver,new Color(0.4588235f, 0.4588235f, 0.4588235f, 1f)},
                    {ColorPalette.Space_Cadet,new Color(0.1137255f, 0.1607843f, 0.3176471f, 1f)},
                    {ColorPalette.Spanish_Bistre,new Color(0.5019608f, 0.4588235f, 0.1960784f, 1f)},
                    {ColorPalette.Spanish_Blue,new Color(0f, 0.4392157f, 0.7215686f, 1f)},
                    {ColorPalette.Spanish_Carmine,new Color(0.8196079f, 0f, 0.2784314f, 1f)},
                    {ColorPalette.Spanish_Gray,new Color(0.5960785f, 0.5960785f, 0.5960785f, 1f)},
                    {ColorPalette.Spanish_Green,new Color(0f, 0.5686275f, 0.3137255f, 1f)},
                    {ColorPalette.Spanish_Orange,new Color(0.9098039f, 0.3803922f, 0f, 1f)},
                    {ColorPalette.Spanish_Pink,new Color(0.9686275f, 0.7490196f, 0.7450981f, 1f)},
                    {ColorPalette.Spanish_Red,new Color(0.9019608f, 0f, 0.1490196f, 1f)},
                    {ColorPalette.Spanish_Sky_Blue,new Color(0f, 1f, 1f, 1f)},
                    {ColorPalette.Spanish_Violet,new Color(0.2980392f, 0.1568628f, 0.509804f, 1f)},
                    {ColorPalette.Spanish_Viridian,new Color(0f, 0.4980392f, 0.3607843f, 1f)},
                    {ColorPalette.Spring_Bud,new Color(0.654902f, 0.9882353f, 0f, 1f)},
                    {ColorPalette.Spring_Frost,new Color(0.5294118f, 1f, 0.1647059f, 1f)},
                    {ColorPalette.Spring_Green,new Color(0f, 1f, 0.4980392f, 1f)},
                    {ColorPalette.Spring_Green_Crayola,new Color(0.9254902f, 0.9215686f, 0.7411765f, 1f)},
                    {ColorPalette.Star_Command_Blue,new Color(0f, 0.4823529f, 0.7215686f, 1f)},
                    {ColorPalette.Steel_Blue,new Color(0.2745098f, 0.509804f, 0.7058824f, 1f)},
                    {ColorPalette.Steel_Pink,new Color(0.8f, 0.2f, 0.8f, 1f)},
                    {ColorPalette.Steel_Teal,new Color(0.372549f, 0.5411765f, 0.5450981f, 1f)},
                    {ColorPalette.Stil_De_Grain_Yellow,new Color(0.9803922f, 0.854902f, 0.3686275f, 1f)},
                    {ColorPalette.Straw,new Color(0.8941177f, 0.8509804f, 0.4352941f, 1f)},
                    {ColorPalette.Sugar_Plum,new Color(0.5686275f, 0.3058824f, 0.4588235f, 1f)},
                    {ColorPalette.Sunglow,new Color(1f, 0.8f, 0.2f, 1f)},
                    {ColorPalette.Sunray,new Color(0.8901961f, 0.6705883f, 0.3411765f, 1f)},
                    {ColorPalette.Sunset,new Color(0.9803922f, 0.8392157f, 0.6470588f, 1f)},
                    {ColorPalette.Super_Pink,new Color(0.8117647f, 0.4196078f, 0.6627451f, 1f)},
                    {ColorPalette.Sweet_Brown,new Color(0.6588235f, 0.2156863f, 0.1921569f, 1f)},
                    {ColorPalette.Tan,new Color(0.8235294f, 0.7058824f, 0.5490196f, 1f)},
                    {ColorPalette.Tan_Crayola,new Color(0.8509804f, 0.6039216f, 0.4235294f, 1f)},
                    {ColorPalette.Tangerine,new Color(0.9490196f, 0.5215687f, 0f, 1f)},
                    {ColorPalette.Tango_Pink,new Color(0.8941177f, 0.4431373f, 0.4784314f, 1f)},
                    {ColorPalette.Tart_Orange,new Color(0.9843137f, 0.3019608f, 0.2745098f, 1f)},
                    {ColorPalette.Taupe,new Color(0.282353f, 0.2352941f, 0.1960784f, 1f)},
                    {ColorPalette.Taupe_Gray,new Color(0.5450981f, 0.5215687f, 0.5372549f, 1f)},
                    {ColorPalette.Tea_Green,new Color(0.8156863f, 0.9411765f, 0.7529412f, 1f)},
                    {ColorPalette.Tea_Rose,new Color(0.972549f, 0.5137255f, 0.4745098f, 1f)},
                    {ColorPalette.Tea_Rose1,new Color(0.9568627f, 0.7607843f, 0.7607843f, 1f)},
                    {ColorPalette.Teal,new Color(0f, 0.5019608f, 0.5019608f, 1f)},
                    {ColorPalette.Teal_Blue,new Color(0.2117647f, 0.4588235f, 0.5333334f, 1f)},
                    {ColorPalette.Telemagenta,new Color(0.8117647f, 0.2039216f, 0.4627451f, 1f)},
                    {ColorPalette.Tenné_Tawny,new Color(0.8039216f, 0.3411765f, 0f, 1f)},
                    {ColorPalette.Terra_Cotta,new Color(0.8862745f, 0.4470588f, 0.3568628f, 1f)},
                    {ColorPalette.Thistle,new Color(0.8470588f, 0.7490196f, 0.8470588f, 1f)},
                    {ColorPalette.Thulian_Pink,new Color(0.8705882f, 0.4352941f, 0.6313726f, 1f)},
                    {ColorPalette.Tickle_Me_Pink,new Color(0.9882353f, 0.5372549f, 0.6745098f, 1f)},
                    {ColorPalette.Tiffany_Blue,new Color(0.03921569f, 0.7294118f, 0.7098039f, 1f)},
                    {ColorPalette.Timberwolf,new Color(0.8588235f, 0.8431373f, 0.8235294f, 1f)},
                    {ColorPalette.Titanium_Yellow,new Color(0.9333333f, 0.9019608f, 0f, 1f)},
                    {ColorPalette.Tomato,new Color(1f, 0.3882353f, 0.2784314f, 1f)},
                    {ColorPalette.Tropical_Rainforest,new Color(0f, 0.4588235f, 0.3686275f, 1f)},
                    {ColorPalette.True_Blue,new Color(0.1764706f, 0.4078431f, 0.7686275f, 1f)},
                    {ColorPalette.Trypan_Blue,new Color(0.1098039f, 0.01960784f, 0.7019608f, 1f)},
                    {ColorPalette.Tufts_Blue,new Color(0.2431373f, 0.5568628f, 0.8705882f, 1f)},
                    {ColorPalette.Tumbleweed,new Color(0.8705882f, 0.6666667f, 0.5333334f, 1f)},
                    {ColorPalette.Turquoise,new Color(0.2509804f, 0.8784314f, 0.8156863f, 1f)},
                    {ColorPalette.Turquoise_Blue,new Color(0f, 1f, 0.9372549f, 1f)},
                    {ColorPalette.Turquoise_Green,new Color(0.627451f, 0.8392157f, 0.7058824f, 1f)},
                    {ColorPalette.Turtle_Green,new Color(0.5411765f, 0.6039216f, 0.3568628f, 1f)},
                    {ColorPalette.Tuscan,new Color(0.9803922f, 0.8392157f, 0.6470588f, 1f)},
                    {ColorPalette.Tuscan_Brown,new Color(0.4352941f, 0.3058824f, 0.2156863f, 1f)},
                    {ColorPalette.Tuscan_Red,new Color(0.4862745f, 0.282353f, 0.282353f, 1f)},
                    {ColorPalette.Tuscan_Tan,new Color(0.6509804f, 0.4823529f, 0.3568628f, 1f)},
                    {ColorPalette.Tuscany,new Color(0.7529412f, 0.6f, 0.6f, 1f)},
                    {ColorPalette.Twilight_Lavender,new Color(0.5411765f, 0.2862745f, 0.4196078f, 1f)},
                    {ColorPalette.Tyrian_Purple,new Color(0.4f, 0.007843138f, 0.2352941f, 1f)},
                    {ColorPalette.Ua_Blue,new Color(0f, 0.2f, 0.6666667f, 1f)},
                    {ColorPalette.Ua_Red,new Color(0.8509804f, 0f, 0.2980392f, 1f)},
                    {ColorPalette.Ultramarine,new Color(0.2470588f, 0f, 1f, 1f)},
                    {ColorPalette.Ultramarine_Blue,new Color(0.254902f, 0.4f, 0.9607843f, 1f)},
                    {ColorPalette.Ultra_Pink,new Color(1f, 0.4352941f, 1f, 1f)},
                    {ColorPalette.Ultra_Red,new Color(0.9882353f, 0.4235294f, 0.5215687f, 1f)},
                    {ColorPalette.Umber,new Color(0.3882353f, 0.3176471f, 0.2784314f, 1f)},
                    {ColorPalette.Unbleached_Silk,new Color(1f, 0.8666667f, 0.7921569f, 1f)},
                    {ColorPalette.United_Nations_Blue,new Color(0.3568628f, 0.572549f, 0.8980392f, 1f)},
                    {ColorPalette.Unmellow_Yellow,new Color(1f, 1f, 0.4f, 1f)},
                    {ColorPalette.Up_Forest_Green,new Color(0.003921569f, 0.2666667f, 0.1294118f, 1f)},
                    {ColorPalette.Up_Maroon,new Color(0.4823529f, 0.06666667f, 0.07450981f, 1f)},
                    {ColorPalette.Upsdell_Red,new Color(0.682353f, 0.1254902f, 0.1607843f, 1f)},
                    {ColorPalette.Uranian_Blue,new Color(0.6862745f, 0.8588235f, 0.9607843f, 1f)},
                    {ColorPalette.Usafa_Blue,new Color(0f, 0.3098039f, 0.5960785f, 1f)},
                    {ColorPalette.Van_Dyke_Brown,new Color(0.4f, 0.2588235f, 0.1568628f, 1f)},
                    {ColorPalette.Vanilla,new Color(0.9529412f, 0.8980392f, 0.6705883f, 1f)},
                    {ColorPalette.Vanilla_Ice,new Color(0.9529412f, 0.5607843f, 0.6627451f, 1f)},
                    {ColorPalette.Vegas_Gold,new Color(0.772549f, 0.7019608f, 0.345098f, 1f)},
                    {ColorPalette.Venetian_Red,new Color(0.7843137f, 0.03137255f, 0.08235294f, 1f)},
                    {ColorPalette.Verdigris,new Color(0.2627451f, 0.7019608f, 0.682353f, 1f)},
                    {ColorPalette.Vermilion,new Color(0.8901961f, 0.2588235f, 0.2039216f, 1f)},
                    {ColorPalette.Vermilion1,new Color(0.8509804f, 0.2196078f, 0.1176471f, 1f)},
                    {ColorPalette.Veronica,new Color(0.627451f, 0.1254902f, 0.9411765f, 1f)},
                    {ColorPalette.Violet,new Color(0.5607843f, 0f, 1f, 1f)},
                    {ColorPalette.Violet_Color_Wheel,new Color(0.4980392f, 0f, 1f, 1f)},
                    {ColorPalette.Violet_Crayola,new Color(0.5882353f, 0.2392157f, 0.4980392f, 1f)},
                    {ColorPalette.Violet_Ryb,new Color(0.5254902f, 0.003921569f, 0.6862745f, 1f)},
                    {ColorPalette.Violet_Web,new Color(0.9333333f, 0.509804f, 0.9333333f, 1f)},
                    {ColorPalette.Violet_Blue,new Color(0.1960784f, 0.2901961f, 0.6980392f, 1f)},
                    {ColorPalette.Violet_Blue_Crayola,new Color(0.4627451f, 0.4313726f, 0.7843137f, 1f)},
                    {ColorPalette.Violet_Red,new Color(0.9686275f, 0.3254902f, 0.5803922f, 1f)},
                    {ColorPalette.Viridian,new Color(0.2509804f, 0.509804f, 0.427451f, 1f)},
                    {ColorPalette.Viridian_Green,new Color(0f, 0.5882353f, 0.5960785f, 1f)},
                    {ColorPalette.Vivid_Burgundy,new Color(0.6235294f, 0.1137255f, 0.2078431f, 1f)},
                    {ColorPalette.Vivid_Sky_Blue,new Color(0f, 0.8f, 1f, 1f)},
                    {ColorPalette.Vivid_Tangerine,new Color(1f, 0.627451f, 0.5372549f, 1f)},
                    {ColorPalette.Vivid_Violet,new Color(0.6235294f, 0f, 1f, 1f)},
                    {ColorPalette.Volt,new Color(0.8078431f, 1f, 0f, 1f)},
                    {ColorPalette.Warm_Black,new Color(0f, 0.2588235f, 0.2588235f, 1f)},
                    {ColorPalette.Wheat,new Color(0.9607843f, 0.8705882f, 0.7019608f, 1f)},
                    {ColorPalette.White,new Color(1f, 1f, 1f, 1f)},
                    {ColorPalette.Wild_Blue_Yonder,new Color(0.6352941f, 0.6784314f, 0.8156863f, 1f)},
                    {ColorPalette.Wild_Orchid,new Color(0.8313726f, 0.4392157f, 0.6352941f, 1f)},
                    {ColorPalette.Wild_Strawberry,new Color(1f, 0.2627451f, 0.6431373f, 1f)},
                    {ColorPalette.Wild_Watermelon,new Color(0.9882353f, 0.4235294f, 0.5215687f, 1f)},
                    {ColorPalette.Windsor_Tan,new Color(0.654902f, 0.3333333f, 0.007843138f, 1f)},
                    {ColorPalette.Wine,new Color(0.4470588f, 0.1843137f, 0.2156863f, 1f)},
                    {ColorPalette.Wine_Dregs,new Color(0.4039216f, 0.1921569f, 0.2784314f, 1f)},
                    {ColorPalette.Winter_Sky,new Color(1f, 0f, 0.4862745f, 1f)},
                    {ColorPalette.Wintergreen_Dream,new Color(0.3372549f, 0.5333334f, 0.4901961f, 1f)},
                    {ColorPalette.Wisteria,new Color(0.7882353f, 0.627451f, 0.8627451f, 1f)},
                    {ColorPalette.Wood_Brown,new Color(0.7568628f, 0.6039216f, 0.4196078f, 1f)},
                    {ColorPalette.Xanthic,new Color(0.9333333f, 0.9294118f, 0.03529412f, 1f)},
                    {ColorPalette.Xanadu,new Color(0.4509804f, 0.5254902f, 0.4705882f, 1f)},
                    {ColorPalette.Yale_Blue,new Color(0.05882353f, 0.3019608f, 0.572549f, 1f)},
                    {ColorPalette.Yellow,new Color(1f, 1f, 0f, 1f)},
                    {ColorPalette.Yellow_Crayola,new Color(0.9882353f, 0.9098039f, 0.5137255f, 1f)},
                    {ColorPalette.Yellow_Munsell,new Color(0.9372549f, 0.8f, 0f, 1f)},
                    {ColorPalette.Yellow_Ncs,new Color(1f, 0.827451f, 0f, 1f)},
                    {ColorPalette.Yellow_Pantone,new Color(0.9960784f, 0.8745098f, 0f, 1f)},
                    {ColorPalette.Yellow_Process,new Color(1f, 0.9372549f, 0f, 1f)},
                    {ColorPalette.Yellow_Ryb,new Color(0.9960784f, 0.9960784f, 0.2f, 1f)},
                    {ColorPalette.Yellow_Green,new Color(0.6039216f, 0.8039216f, 0.1960784f, 1f)},
                    {ColorPalette.Yellow_Green_Crayola,new Color(0.772549f, 0.8901961f, 0.5176471f, 1f)},
                    {ColorPalette.Yellow_Green_Color_Wheel,new Color(0.1882353f, 0.6980392f, 0.1019608f, 1f)},
                    {ColorPalette.Yellow_Orange,new Color(1f, 0.682353f, 0.2588235f, 1f)},
                    {ColorPalette.Yellow_Orange_Color_Wheel,new Color(1f, 0.5843138f, 0.01960784f, 1f)},
                    {ColorPalette.Yellow_Sunshine,new Color(1f, 0.9686275f, 0f, 1f)},
                    {ColorPalette.Yinmn_Blue,new Color(0.1803922f, 0.3137255f, 0.5647059f, 1f)},
                    {ColorPalette.Zaffre,new Color(0f, 0.07843138f, 0.6588235f, 1f)},
                    {ColorPalette.Zomp,new Color(0.2235294f, 0.654902f, 0.5568628f, 1f)},
                };
            }
        }
    }
}