Friend Module Verbs
    Friend ReadOnly VBs As IReadOnlyDictionary(Of String, Integer) =
        New Dictionary(Of String, Integer) From
        {
            {"GO", 1},
            {"GET", 2},
            {"LOOK", 3},
            {"INVEN", 4},
            {"SCORE", 5},
            {"DROP", 6},
            {"HELP", 7},
            {"SAVE", 8},
            {"LOAD", 9},
            {"QUIT", 10},
            {"PRESS", 11},
            {"SHOOT", 12},
            {"SAY", 13},
            {"READ", 14},
            {"EAT", 15},
            {"CSAVE", 16},
            {"SHOW", 17},
            {"OPEN", 18},
            {"FEED", 19},
            {"HIT", 20},
            {"KILL", 21}
        }
    Friend ReadOnly LV As Integer = VBs.Values.Max
End Module
