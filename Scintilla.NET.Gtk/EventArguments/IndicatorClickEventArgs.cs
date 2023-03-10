using ScintillaNet.Abstractions;
using ScintillaNet.Abstractions.EventArguments;
using Key = Gdk.Key;

namespace ScintillaNet.Gtk.EventArguments;

/// <summary>
/// Provides data for the <see cref="Scintilla.IndicatorClick" /> event.
/// </summary>
public class IndicatorClickEventArgs : IndicatorClickEventArgsBase<Key>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="IndicatorClickEventArgs" /> class.
    /// </summary>
    /// <param name="scintilla">The <see cref="Scintilla" /> control that generated this event.</param>
    /// <param name="modifiers">The modifier keys that where held down at the time of the click.</param>
    public IndicatorClickEventArgs(
        IScintillaApi scintilla, 
        Key modifiers) : base(scintilla, modifiers)
    {
    }
}