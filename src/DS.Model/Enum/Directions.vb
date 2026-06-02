Friend Module Directions
    Friend ReadOnly DIRECTION_NAMES As IReadOnlyDictionary(Of Integer, String) =
        New Dictionary(Of Integer, String) From
        {
            {DIRECTION_0, "north"},
            {DIRECTION_1, "east"},
            {DIRECTION_2, "south"},
            {DIRECTION_3, "west"},
            {DIRECTION_4, "up"},
            {DIRECTION_5, "down"}
        }
End Module
