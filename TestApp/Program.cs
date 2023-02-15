﻿using Gtk;
using System;
using Gdk;
using ScintillaNet.Abstractions.Classes;
using ScintillaNet.Abstractions.Classes.Lexers;
using ScintillaNet.Abstractions.Enumerations;
using ScintillaNet.Gtk;
using Window = Gtk.Window;

class MainWindow {
 
    static void Main()
    {
        Application.Init ();
 
        var window = new Window ("Scintilla.NET.Gtk TestApp");
        // when this window is deleted, it'll run delete_event()
        window.DeleteEvent += delete_event;

        scintilla = new Scintilla();
        
        window.Add(scintilla);

        window.Resize(500, 600);
        CreateCsStyling();
        window.ShowAll ();
 
        Application.Run ();
    }

    private static Scintilla scintilla;
 
    // runs when the user deletes the window using the "close
    // window" widget in the window frame.
    static void delete_event (object obj, DeleteEventArgs args)
    {
        Application.Quit ();
    }
    
    private static void CreateCsStyling()
    {
        Color FromHtml(string value)
        {
            var color = new Color();
            Color.Parse(value, ref color);
            return color;
        }
        
        scintilla.Styles[Cpp.Preprocessor].ForeColor = FromHtml("#804000");
        scintilla.Styles[Cpp.Preprocessor].BackColor = FromHtml("#FFFFFF");
        scintilla.Styles[Cpp.Default].ForeColor = FromHtml("#000000");
        scintilla.Styles[Cpp.Default].BackColor = FromHtml("#FFFFFF");
        scintilla.Styles[Cpp.Word].ForeColor = FromHtml("#0000FF");
        scintilla.Styles[Cpp.Word].BackColor = FromHtml("#FFFFFF");
        scintilla.Styles[Cpp.Word2].ForeColor = FromHtml("#8000FF");
        scintilla.Styles[Cpp.Word2].BackColor = FromHtml("#FFFFFF");
        scintilla.Styles[Cpp.Number].ForeColor = FromHtml("#FF8000");
        scintilla.Styles[Cpp.Number].BackColor = FromHtml("#FFFFFF");
        scintilla.Styles[Cpp.String].ForeColor = FromHtml("#000080");
        scintilla.Styles[Cpp.String].BackColor = FromHtml("#FFFFFF");
        scintilla.Styles[Cpp.Character].ForeColor = FromHtml("#000000");
        scintilla.Styles[Cpp.Character].BackColor = FromHtml("#FFFFFF");
        scintilla.Styles[Cpp.Operator].Bold = true;
        scintilla.Styles[Cpp.Operator].ForeColor = FromHtml("#000080");
        scintilla.Styles[Cpp.Operator].BackColor = FromHtml("#FFFFFF");
        scintilla.Styles[Cpp.Verbatim].ForeColor = FromHtml("#000000");
        scintilla.Styles[Cpp.Verbatim].BackColor = FromHtml("#FFFFFF");
        scintilla.Styles[Cpp.Regex].Bold = true;
        scintilla.Styles[Cpp.Regex].ForeColor = FromHtml("#000000");
        scintilla.Styles[Cpp.Regex].BackColor = FromHtml("#FFFFFF");
        scintilla.Styles[Cpp.Comment].ForeColor = FromHtml("#008000");
        scintilla.Styles[Cpp.Comment].BackColor = FromHtml("#FFFFFF");
        scintilla.Styles[Cpp.CommentLine].ForeColor = FromHtml("#008080");
        scintilla.Styles[Cpp.CommentLine].BackColor = FromHtml("#FFFFFF");
        scintilla.Styles[Cpp.CommentDoc].ForeColor = FromHtml("#008080");
        scintilla.Styles[Cpp.CommentDoc].BackColor = FromHtml("#FFFFFF");
        scintilla.Styles[Cpp.CommentLineDoc].ForeColor = FromHtml("#008080");
        scintilla.Styles[Cpp.CommentLineDoc].BackColor = FromHtml("#FFFFFF");
        scintilla.Styles[Cpp.CommentDocKeyword].Bold = true;
        scintilla.Styles[Cpp.CommentDocKeyword].ForeColor = FromHtml("#008080");
        scintilla.Styles[Cpp.CommentDocKeyword].BackColor = FromHtml("#FFFFFF");
        scintilla.Styles[Cpp.CommentDocKeywordError].ForeColor = FromHtml("#008080");
        scintilla.Styles[Cpp.CommentDocKeywordError].BackColor = FromHtml("#FFFFFF");
        scintilla.Styles[Cpp.PreprocessorComment].ForeColor = FromHtml("#008000");
        scintilla.Styles[Cpp.PreprocessorComment].BackColor = FromHtml("#FFFFFF");
        scintilla.Styles[Cpp.PreprocessorCommentDoc].ForeColor = FromHtml("#008080");
        scintilla.Styles[Cpp.PreprocessorCommentDoc].BackColor = FromHtml("#FFFFFF");

        scintilla.LexerName = "cpp";

        scintilla.SetKeywords(0,
            "alignof and and_eq bitand bitor break case catch compl const_cast continue default delete do dynamic_cast else false for goto if namespace new not not_eq nullptr operator or or_eq reinterpret_cast return sizeof static_assert static_cast switch this throw true try typedef typeid using while xor xor_eq NULL");
        scintilla.SetKeywords(1,
            "alignas asm auto bool char char16_t char32_t class clock_t const constexpr decltype double enum explicit export extern final float friend inline int int8_t int16_t int32_t int64_t int_fast8_t int_fast16_t int_fast32_t int_fast64_t intmax_t intptr_t long mutable noexcept override private protected ptrdiff_t public register short signed size_t ssize_t static struct template thread_local time_t typename uint8_t uint16_t uint32_t uint64_t uint_fast8_t uint_fast16_t uint_fast32_t uint_fast64_t uintmax_t uintptr_t union unsigned virtual void volatile wchar_t");
        scintilla.SetKeywords(2,
            "a addindex addtogroup anchor arg attention author authors b brief bug c callergraph callgraph category cite class code cond copybrief copydetails copydoc copyright date def defgroup deprecated details diafile dir docbookonly dontinclude dot dotfile e else elseif em endcode endcond enddocbookonly enddot endhtmlonly endif endinternal endlatexonly endlink endmanonly endmsc endparblock endrtfonly endsecreflist enduml endverbatim endxmlonly enum example exception extends f$ f[ f] file fn f{ f} headerfile hidecallergraph hidecallgraph hideinitializer htmlinclude htmlonly idlexcept if ifnot image implements include includelineno ingroup interface internal invariant latexinclude latexonly li line link mainpage manonly memberof msc mscfile n name namespace nosubgrouping note overload p package page par paragraph param parblock post pre private privatesection property protected protectedsection protocol public publicsection pure ref refitem related relatedalso relates relatesalso remark remarks result return returns retval rtfonly sa secreflist section see short showinitializer since skip skipline snippet startuml struct subpage subsection subsubsection tableofcontents test throw throws todo tparam typedef union until var verbatim verbinclude version vhdlflow warning weakgroup xmlonly xrefitem");

        scintilla.SetProperty("fold", "1");
        scintilla.SetProperty("fold.compact", "1");
        scintilla.SetProperty("fold.preprocessor", "1");

        // Configure a margin to display folding symbols
        scintilla.Margins[2].Type = MarginType.Symbol;
        scintilla.Margins[2].Mask = MarkerConstants.MaskFolders;
        scintilla.Margins[2].Sensitive = true;
        scintilla.Margins[2].Width = 20;

        var c1 = FromHtml("#F5F3ED");
        var c2 = FromHtml("#5E5C56");

        // Set colors for all folding markers
        for (var i = 25; i <= 31; i++)
        {
            scintilla.Markers[i].SetForeColor(c1);
            scintilla.Markers[i].SetBackColor(c2);
        }

        // Configure folding markers with respective symbols
        scintilla.Markers[MarkerConstants.Folder].Symbol = MarkerSymbol.BoxPlus;
        scintilla.Markers[MarkerConstants.FolderOpen].Symbol = MarkerSymbol.BoxMinus;
        scintilla.Markers[MarkerConstants.FolderEnd].Symbol = MarkerSymbol.BoxPlusConnected;
        scintilla.Markers[MarkerConstants.FolderMidTail].Symbol = MarkerSymbol.TCorner;
        scintilla.Markers[MarkerConstants.FolderOpenMid].Symbol = MarkerSymbol.BoxMinusConnected;
        scintilla.Markers[MarkerConstants.FolderSub].Symbol = MarkerSymbol.VLine;
        scintilla.Markers[MarkerConstants.FolderTail].Symbol = MarkerSymbol.LCorner;

        // Enable automatic folding
        scintilla.AutomaticFold = (AutomaticFold.Show | AutomaticFold.Click | AutomaticFold.Change);
    }
}