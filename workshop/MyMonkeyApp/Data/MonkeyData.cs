using MyMonkeyApp.Models;

namespace MyMonkeyApp.Data;

public static class MonkeyData
{
    public static List<Monkey> GetMonkeys()
    {
        return new List<Monkey>
        {
            new Monkey
            {
                Name = "Baboon",
                Location = "Africa & Arabia",
                Details = "Baboons are African and Arabian Old World monkeys belonging to the genus Papio, part of the subfamily Cercopithecinae.",
                Species = "Papio",
                Age = 15,
                Image = "🐵",
                Population = 10000,
                Latitude = -8.783195,
                Longitude = 34.508523
            },
            new Monkey
            {
                Name = "Capuchin Monkey",
                Location = "Central & South America",
                Details = "The capuchin monkeys are New World monkeys of the subfamily Cebinae. They are readily identified as the 'organ grinder' monkey, and have been used in many movies and television shows.",
                Species = "Cebus",
                Age = 20,
                Image = "🐒",
                Population = 23000,
                Latitude = 10.1967,
                Longitude = -84.0486
            },
            new Monkey
            {
                Name = "Blue Monkey",
                Location = "Central and East Africa",
                Details = "The blue monkey or diademed monkey is a species of Old World monkey native to Central and East Africa, ranging from the upper Congo River basin east to the East African Rift and south to northern Angola and Zambia",
                Species = "Cercopithecus mitis",
                Age = 18,
                Image = "🐵",
                Population = 200000,
                Latitude = -4.6949,
                Longitude = 23.1941
            },
            new Monkey
            {
                Name = "Squirrel Monkey",
                Location = "Central & South America",
                Details = "The common squirrel monkey is a small New World monkey of the family Cebidae. Native to the tropical forests of Central and South America, it lives in the canopy in large groups.",
                Species = "Saimiri sciureus",
                Age = 12,
                Image = "🐒",
                Population = 300000,
                Latitude = -2.9814,
                Longitude = -60.0348
            },
            new Monkey
            {
                Name = "Golden Lion Tamarin",
                Location = "Brazil",
                Details = "The golden lion tamarin also known as the golden marmoset, is a small New World monkey of the family Callitrichidae.",
                Species = "Leontopithecus rosalia",
                Age = 10,
                Image = "🦁",
                Population = 3000,
                Latitude = -22.9068,
                Longitude = -43.1729
            },
            new Monkey
            {
                Name = "Howler Monkey",
                Location = "Central & South America",
                Details = "Howler monkeys are among the largest of the New World monkeys. Fifteen species are currently recognised. Previously classified in the family Cebidae, they are now placed in the family Atelidae.",
                Species = "Alouatta",
                Age = 16,
                Image = "🐵",
                Population = 50000,
                Latitude = 18.7357,
                Longitude = -70.1627
            },
            new Monkey
            {
                Name = "Japanese Macaque",
                Location = "Japan",
                Details = "The Japanese macaque, is a terrestrial Old World monkey species that is native to Japan. They are also sometimes known as the snow monkey because they live in areas where snow covers the ground for months each year – no other non-human primate is more northern-living, nor lives in a colder climate.",
                Species = "Macaca fuscata",
                Age = 25,
                Image = "🐵",
                Population = 114000,
                Latitude = 36.204824,
                Longitude = 138.252924
            },
            new Monkey
            {
                Name = "Mandrill",
                Location = "Equatorial Africa",
                Details = "The mandrill is a primate of the Old World monkey family, closely related to the baboons and even more closely to the drill. It is found in southern Cameroon, Equatorial Guinea, Gabon, and the Republic of the Congo.",
                Species = "Mandrillus sphinx",
                Age = 20,
                Image = "🐵",
                Population = 7000,
                Latitude = -0.8037,
                Longitude = 11.6094
            },
            new Monkey
            {
                Name = "Proboscis Monkey",
                Location = "Borneo",
                Details = "The proboscis monkey or long-nosed monkey, known as the bekantan in Indonesia, is a reddish-brown arboreal Old World monkey with an unusually large nose. It is endemic to the southeast Asian island of Borneo.",
                Species = "Nasalis larvatus",
                Age = 15,
                Image = "🐵",
                Population = 7000,
                Latitude = 1.5167,
                Longitude = 110.3167
            },
            new Monkey
            {
                Name = "Red-shanked Douc",
                Location = "Vietnam, Laos",
                Details = "The red-shanked douc is a species of Old World monkey, among the most colourful of all primates. This monkey is sometimes called the 'costumed ape' for its extravagant appearance. From its knees to its ankles it sports maroon-red 'stockings', and it appears to be wearing white forearm guards. The golden face is framed by a white ruff, which is considerably fluffier in males.",
                Species = "Pygathrix nemaeus",
                Age = 18,
                Image = "🐵",
                Population = 1000,
                Latitude = 16.0544,
                Longitude = 108.2022
            }
        };
    }
}