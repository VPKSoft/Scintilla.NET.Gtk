using System;
using ScintillaNet.Abstractions;
using ScintillaNet.Abstractions.EventArguments;
using ScintillaNet.Abstractions.Interfaces.Collections;

namespace ScintillaNet.Gtk.EventArguments;

/// <summary>
/// Provides data for the Scintilla.AutoCSelectionChange event.
/// </summary>
public class AutoCSelectionChangeEventArgs : AutoCSelectionChangeEventArgsBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AutoCSelectionChangeEventArgs" /> class.
    /// </summary>
    /// <param name="scintilla">The <see cref="scintilla" /> control that generated this event.</param>
    /// <param name="lineCollectionGeneral">A reference to Scintilla's line collection.</param>/// 
    /// <param name="text">A pointer to the selected auto-completion text.</param>
    /// <param name="bytePosition">The zero-based byte position within the document where the list was displayed.</param>
    /// <param name="listType">The list type of the user list, or 0 for an auto-completion.</param>    
    public AutoCSelectionChangeEventArgs(
        IScintillaApi scintilla,
        IScintillaLineCollectionGeneral lineCollectionGeneral, 
        IntPtr text, 
        int bytePosition, 
        int listType) : base(scintilla, lineCollectionGeneral, text, bytePosition, listType)
    {
    }
}