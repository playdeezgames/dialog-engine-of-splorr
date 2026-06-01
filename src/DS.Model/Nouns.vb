Friend Module Nouns
    Friend ReadOnly NOs As IReadOnlyDictionary(Of String, Integer) =
        New Dictionary(Of String, Integer) From
        {
            {"NORTH", 1},
            {"EAST", 2},
            {"SOUTH", 3},
            {"WEST", 4},
            {"UP", 5},
            {"DOWN", 6},
            {"BUTTON", 10},
            {"TAG", 11},
            {"FUEL", 12},
            {"BLASTER", 13},
            {"COMMUNICATOR", 14},
            {"GUARD", 15},
            {"MAP", 16},
            {"KEYS", 17},
            {"NECKLACE", 18},
            {"SESAME", 19},
            {"GRAFFITI", 20},
            {"CAPE", 21},
            {"HAMBURGER", 22},
            {"TAPE", 23},
            {"TURBO", 24},
            {"SCIENTIST", 25},
            {"PLANS", 26},
            {"SCHEMATIC", 27},
            {"DEVICE", 28},
            {"GUN", 29},
            {"SECURITY", 30},
            {"I.D.", 31},
            {"CRYSTALS", 32},
            {"SIGN", 33},
            {"ROBOT", 34},
            {"PRINCESS", 35},
            {"DOOR", 36},
            {"AMMUNITION", 37}
        }
    Friend ReadOnly LN As Integer = NOs.Values.Max
End Module
