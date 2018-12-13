//////////////////////////////////////////////////////////////////////
//
// Readme file for ComponentOne C1Pdf
//
// C1.C1Pdf.dll
//
//////////////////////////////////////////////////////////////////////


=========================================================================================       
C1.C1Pdf.dll Build Number 1.1.20071.59	Build Date: November 23, 2006
========================================================================================= 

Enhancements/Documentation/Behavior Changes 
------------------------------------------- 
 * Improved text clipping when redering metafiles
 

=========================================================================================       
C1.C1Pdf.dll Build Number 1.1.20071.58	Build Date: November 7, 2006
========================================================================================= 

Enhancements/Documentation/Behavior Changes 
------------------------------------------- 
 * Improved text measurement logic (more precise right-alignment in DrawString).
 
 * Added method for measuring the width of Rtf strings
   For example:
		public SizeF MeasureStringRtf(string text, Font font)
	
 * Added support for StringFormat.StringTrimming in DrawString method (with or without wrapping).
   For example:
		StringFormat sf = new StringFormat();
		sf.Trimming = StringTrimming.EllipsisWord;
		_pdf1.DrawString(text, font, Brushes.Black, rc, sf);
   

=========================================================================================       
C1.C1Pdf.dll Build Number 1.1.20071.57	Build Date: October 13, 2006
========================================================================================= 

Corrections 
----------- 
 * Using 'Marlett' font in the DrawString() caused error in Acrobat Reader (font contains bad widths). (VNPDF000092)
   This bug was introduced in build 48, with adding improved support for Japanese characters.

=========================================================================================       
C1.C1Pdf.dll Build Number 1.1.20071.56	Build Date: October 12, 2006
========================================================================================= 

Enhancements/Documentation/Behavior Changes 
------------------------------------------- 
 * Improved rendering of wmf images (render as metafiles)
 * Optimized rendering of 32 bpp images

=========================================================================================       
C1.C1Pdf.dll Build Number 1.1.20071.55	Build Date: October 2, 2006
========================================================================================= 

Enhancements/Documentation/Behavior Changes 
------------------------------------------- 
 * V1/2007 build.

=========================================================================================       
C1.C1Pdf.dll Build Number 1.1.20063.55	Build Date: September 20, 2006
========================================================================================= 

Corrections 
----------- 
 * Fixed GDI leak rendering some types of image. (Bug was introduced in build 50).

=========================================================================================       
C1.C1Pdf.dll Build Number 1.1.20063.54	Build Date: July 21, 2006
========================================================================================= 

Enhancements/Documentation/Behavior Changes 
------------------------------------------- 
 * Improved performance in rendering multi-page Rtf strings.

=========================================================================================       
C1.C1Pdf.dll Build Number 1.1.20063.53	Build Date: July 5, 2006
========================================================================================= 

Enhancements/Documentation/Behavior Changes 
------------------------------------------- 
 * V3/2006 build.
 * Added new property: ViewerPreferences
 
   The ViewerPreferences property determines how the document is initially displayed in the Viewer.
   It contains the following sub-properties:
      
        public PageModeEnum PageMode		// Gets or sets how the document should be displayed when opened.
        public PageLayoutEnum PageLayout	// Gets or sets the page layout to be used when the document is opened.
        public bool HideToolBar				// Gets or sets whether to hide the viewer tool bars when the document is active.
        public bool HideMenuBar				// Gets or sets whether to hide the viewer menu bar when the document is active.
        public bool FitWindow				// Gets or sets whether to resize the document's window to fit the size of the first displayed page.
        public bool CenterWindow			// Gets or sets whether to position the document's window in the center of the screen.
   
 * Added return value to DrawStringRtf method and an overload that takes the initial character to render.
   These additions make it possible to flow Rtf text into multi-page documents. For example:
   
        // calculate page rectangle
        RectangleF rcPage = _c1pdf.PageRectangle;
        rcPage.Inflate(-72, -72);
        
        // get Rtf to render
        string text = richTextBox1.Rtf;

        // print the Rtf string spanning multiple pages
        _c1pdf.Clear();
        for (int start = 0; start < int.MaxValue; )
        {
            if (start > 0) _c1pdf.NewPage();
            start = _c1pdf.DrawStringRtf(text, Font, Brushes.Black, rcPage, start);
        }

        // show the result
        string fn = @"c:\temp\test\rtf.pdf";
        _c1pdf.Save(fn);
        System.Diagnostics.Process.Start(fn);
        
 * Added overloads to DrawString with a parameter that specifies the position within
   the string where printing will start. 
   This makes the DrawString and DrawStringRtf methods more consistent.
 * Optimized DrawString, rendering long strings is now much faster than in previous 
   versions.
 
=========================================================================================       
C1.C1Pdf.dll Build Number 1.1.20062.51	Build Date: May 25, 2006
========================================================================================= 

Enhancements/Documentation/Behavior Changes 
------------------------------------------- 
 * Added new property: PdfDocumentInfo.CreationDate.
   By default, this property is set to DateTime.MinValue, which causes the component
   to use the date/time when the document is written to disk.

Corrections 
----------- 
 * Added time zone offset to document creation date.
  
=========================================================================================       
C1.C1Pdf.dll Build Number 1.1.20062.50	Build Date: May 3, 2006
========================================================================================= 

Enhancements/Documentation/Behavior Changes 
------------------------------------------- 
 * Improved performance and compression of images contained in metafiles. The difference
   is especially noticeable in large jpg images, which didn't compress well in earlier versions.

Corrections 
----------- 
 * Fixed rendering of some Rtf text with Unicode characters 
   (including Hebrew text encoded in Rtf with the ETO_GLYPH_INDEX flag)

=========================================================================================       
C1.C1Pdf.dll Build Number 1.1.20062.49	Build Date: February 28, 2006
========================================================================================= 

Enhancements/Documentation/Behavior Changes 
------------------------------------------- 
 * none

Corrections 
----------- 
 * Improved text clipping (Delta issue VNPRV000485)
 * Fixed rendering of symbol and unicode fonts when fonts are not embedded (Delta issue 
   VNRPT000337)

=========================================================================================       
C1.C1Pdf.dll Build Number 1.1.20062.48	Build Date: February 22, 2006
========================================================================================= 

Enhancements/Documentation/Behavior Changes 
------------------------------------------- 
 * Improved rendering of Japanese characters

Corrections 
----------- 
 * none
 
=========================================================================================       
C1.C1Pdf.dll Build Number 1.1.20062.46	Build Date: January 22, 2006
========================================================================================= 

Enhancements/Documentation/Behavior Changes 
------------------------------------------- 
 * V2/2006 build

Corrections 
----------- 
 * Delta fixes:
   VNPDF000054: could throw when measuring strings with small 'width' parameter
   VNPDF000037: some methods in PdfPageCollection did not show in C# Intellisense


=========================================================================================       
C1.C1Pdf.dll Build Number 1.1.20061.46	Build Date: December 1, 2005
========================================================================================= 

Enhancements/Documentation/Behavior Changes 
------------------------------------------- 
 * none

Corrections 
----------- 
 * Updated Japanese localization strings


=========================================================================================       
C1.C1Pdf.dll Build Number 1.1.20061.45	Build Date: November 8, 2005
========================================================================================= 

Enhancements/Documentation/Behavior Changes 
------------------------------------------- 
 * none

Corrections 
----------- 
 * Improved color precision when saving bitmaps


=========================================================================================       
C1.C1Pdf.dll Build Number 1.1.20061.44	Build Date: October 19, 2005
========================================================================================= 

Enhancements/Documentation/Behavior Changes 
------------------------------------------- 
 * V1/2006


=========================================================================================       
C1.C1Pdf.dll Build Number 1.1.20053.44	Build Date: July 12, 2005
========================================================================================= 

Enhancements/Documentation/Behavior Changes 
------------------------------------------- 
 * none

Corrections 
----------- 
 * Improved speed/compression when saving monochrome bitmaps


=========================================================================================       
C1.C1Pdf.dll Build Number 1.1.20053.43	Build Date: July 12, 2005
========================================================================================= 

Enhancements/Documentation/Behavior Changes 
------------------------------------------- 
 * none

Corrections 
----------- 
 * Improved rendering of EMR_PIE metafile records (when using the same point, should draw full ellipse) 
 * Improved metafile path clipping operations


=========================================================================================       
C1.C1Pdf.dll Build Number 1.1.20053.42	Build Date: May 25, 2005
========================================================================================= 

Enhancements/Documentation/Behavior Changes 
------------------------------------------- 
 * V3/2005 build.
 * Added two new DrawString overloads to improve compatibility with Graphics object model:
	public int DrawString(string text, Font font, Brush brush, PointF pt, StringFormat sf)
	public int DrawString(string text, Font font, Brush brush, PointF pt)

Corrections 
----------- 
 * Improve measuring/alignment for fonts with units other than Points (i.e. Pixel, Inch) (VNPDF000047)
 * Improved duplicate image detection to reduce Pdf file size (VNPDF000050)  
 

=========================================================================================       
C1.C1Pdf.dll Build Number 1.1.20052.40	Build Date: February 17, 2005
========================================================================================= 

Enhancements/Documentation/Behavior Changes 
------------------------------------------- 
 * V2/2005 build.
 * Improved FillRectangle method to support non-solid brushes (gradients, textures, etc)

Corrections 
----------- 
 * Improved line-breaking logic to deal with lines that are wider than the page
   (previous change in build 35 was not correct)
 * Improved page-size selection logic to handle paperKinds that have the same size (VNPDF000026)
 * Improved evaluation check on ASP.NET apps.


=========================================================================================       
C1.C1Pdf.dll Build Number 1.1.20051.35	Build Date: November 1, 2004
========================================================================================= 

Enhancements/Documentation/Behavior Changes 
------------------------------------------- 
 * Q1/2005 drop
 * Improved line-breaking logic to deal with lines that are wider than the page

Corrections 
----------- 
 ** improved rendering of non-standard RTF bullets
 ** removed references to printer hdcs (uses screen hdc now, except for Rtf text)
 ** improved rendering of paths in metafiles

=========================================================================================       
C1.C1Pdf.dll Build Number 1.1.20044.35	Build Date: October 9, 2004
========================================================================================= 

Enhancements/Documentation/Behavior Changes 
------------------------------------------- 
 * more thread-safety for use in ASP.NET applications
   (drawing Rtf strings could fail under some multi-threaded scenarios)
 * added support for Arabic text

Corrections 
----------- 
 ** none

=========================================================================================       
C1.C1Pdf.dll Build Number 1.1.20044.34	Build Date: September 9, 2004
========================================================================================= 

Enhancements/Documentation/Behavior Changes 
------------------------------------------- 
 * added thread-safety for use in ASP.NET applications
   (could fail to embed fonts properly under some multi-threaded scenarios)

Corrections 
----------- 
 ** none

=========================================================================================       
C1.C1Pdf.dll Build Number 1.1.20044.33	Build Date: August 31, 2004
========================================================================================= 

Enhancements/Documentation/Behavior Changes 
------------------------------------------- 
 * added Xml documentation for use with D2H Documenter

Corrections 
----------- 
 ** none

=========================================================================================       
C1.C1Pdf.dll Build Number 1.1.20044.32	Build Date: August 9, 2004
========================================================================================= 

Enhancements/Documentation/Behavior Changes 
------------------------------------------- 
 * Q4/2004 build
 * updated licensing to include ASP.NET studio

Corrections 
----------- 
 ** none

=========================================================================================       
C1.C1Pdf.dll Build Number 1.1.20043.31	Build Date: June 24, 2004
========================================================================================= 

Enhancements/Documentation/Behavior Changes 
------------------------------------------- 
 * none

Corrections 
----------- 
 ** improved support for plus/dual metafiles in low-resolution printerless systems

=========================================================================================       
C1.C1Pdf.dll Build Number 1.1.20043.30	Build Date: June 8, 2004
========================================================================================= 

Enhancements/Documentation/Behavior Changes 
------------------------------------------- 
 * added support for inter-character spacing in metafiles (supports justified text)

Corrections 
----------- 
 ** improved support for clipping operations in metafiles
 ** improved scaling of display-based metafiles

=========================================================================================       
C1.C1Pdf.dll Build Number 1.1.20043.28   Build Date: May 6, 2004
========================================================================================= 

Enhancements/Documentation/Behavior Changes 
------------------------------------------- 
 * none

Corrections 
----------- 
 ** improved handling of clipping commands in metafiles

=========================================================================================       
C1.C1Pdf.dll Build Number 1.1.20043.27   Build Date: May 3, 2004
========================================================================================= 

Enhancements/Documentation/Behavior Changes 
------------------------------------------- 
 * Q3/2004

Corrections 
----------- 
 ** none

=========================================================================================       
C1.C1Pdf.dll Build Number 1.1.20042.27   Build Date: April 26, 2004
========================================================================================= 

Enhancements/Documentation/Behavior Changes 
------------------------------------------- 
 * none

Corrections 
----------- 
 ** Improved Japanese line breaking rules

=========================================================================================       
C1.C1Pdf.dll Build Number 1.1.20042.26   Build Date: April 22, 2004
========================================================================================= 

Enhancements/Documentation/Behavior Changes 
------------------------------------------- 
 * none

Corrections 
----------- 
 ** Handle GDI charset in metafiles and rtf
 ** Improved handling of MS UI-type Japanese fonts (was saving multiple font subsets)
 ** Fixed PageCollection.Insert/InsertRange methods in documents with varying page sizes
 ** Handle fonts created in units other than points
 ** Added range checking for page sizes (can't be negative)
 ** Improved saving outline after removing pages
 ** Improved rtf character encoding (required any chars > 126)
 ** Fixed font embedding in encrypted documents (wasn't working on multiple saves)
 ** Added extra checks to font creation in Rtf renderer (failed with non-TrueType fonts)


=========================================================================================       
C1.C1Pdf.dll Build Number 1.1.20042.20   Build Date: April 2, 2004
========================================================================================= 

Enhancements/Documentation/Behavior Changes 
------------------------------------------- 
 * none

Corrections 
----------- 
 ** Handle vertical gdi fonts (by converting them to horizontal fonts, for now)
 ** Fixed image alignment within rectangles with negative dimensions (width/height)
 ** Added extra checks to PdfPageCollection to prevent mxing pages from different documents
 ** Improve rendering of RTF strings that contains invalid RTF commands and Unicode strings
 ** Improved handling of Pages.InsertRange/RemoveRange
 ** Improved handling of PaperKind property when setting CurrentPage property


=========================================================================================       
C1.C1Pdf.dll Build Number 1.1.20042.19   Build Date: March 18, 2004
========================================================================================= 

Enhancements/Documentation/Behavior Changes 
------------------------------------------- 
 * Added support for metafile clipping operations (EmfIntersectClipRect/EmfSelectClipPath)
 * Added Japanese resources
 * Added line break logic for Japanese strings

Corrections 
----------- 
 ** Improved support for unicode attachments and links
 ** Allow to save the same document multiple times


=========================================================================================       
C1.C1Pdf.dll Build Number 1.1.20042.16   Build Date: March 11, 2004
========================================================================================= 

Enhancements/Documentation/Behavior Changes 
------------------------------------------- 
 * improved precision of metafile scaling (size and position)

Corrections 
----------- 
 ** handle images that don't specify resolution (e.g. TIFFs) 
 ** improved image clipping
 ** improved rendering of masked monochrome images in metafiles
 ** fixed problem with file attachments (colors, encryption)
 ** improved rendering of embedded non-ascii chars
 ** improved argument type-checking in PageCollection methods


=========================================================================================       
C1.C1Pdf.dll Build Number 1.1.20042.11   Build Date: February 26, 2004
========================================================================================= 

Enhancements/Documentation/Behavior Changes 
------------------------------------------- 
 * none

Corrections 
----------- 
 ** setting FontType property to Standard threw exception 
 ** rendering right-aligned strings made up of spaces created invalid pdf files
 ** support Unicode characters in DrawStringRtf method
 ** improved font handling in mixed unicode/ASCII documents


=========================================================================================       
C1.C1Pdf.dll Build Number 1.1.20042.10   Build Date: February 19, 2004
========================================================================================= 

Enhancements/Documentation/Behavior Changes 
------------------------------------------- 
 * Q2/2004 build

Corrections 
----------- 
 ** none


=========================================================================================       
C1.C1Pdf.dll Build Number 1.1.20041.10   Build Date: February 16, 2004
========================================================================================= 

Enhancements/Documentation/Behavior Changes 
------------------------------------------- 
 * none

Corrections 
----------- 
 ** Improved management of reference graphics used to render RTF 


=========================================================================================       
C1.C1Pdf.dll Build Number 1.1.20041.9   Build Date: February 9, 2004
========================================================================================= 

Enhancements/Documentation/Behavior Changes 
------------------------------------------- 
 * none

Corrections 
----------- 
 ** Fixed string clipping in Win98 metafiles


=========================================================================================       
C1.C1Pdf.dll Build Number 1.1.20041.8   Build Date: February 5, 2004
========================================================================================= 

Enhancements/Documentation/Behavior Changes 
------------------------------------------- 
 * none

Corrections 
----------- 
 ** Fixed embedded metafile scaling in Win98
	(to test: render a C1FlexGrid into a C1PrintDocument under Win98, then export to pdf)


=========================================================================================       
C1.C1Pdf.dll Build Number 1.1.20041.7   Build Date: December 30, 2003 
========================================================================================= 

Enhancements/Documentation/Behavior Changes 
------------------------------------------- 
 * Improved precision of string clipping when rendering metafiles

Corrections 
----------- 
 ** none


=========================================================================================       
C1.C1Pdf.dll Build Number 1.1.20041.6   Build Date: December 9, 2003 
========================================================================================= 

Enhancements/Documentation/Behavior Changes 
------------------------------------------- 
 * Improved appearance of non-solid lines (dash, dot, etc)

Corrections 
----------- 
 ** Handle hyperlinks in scaled metafiles (rare but possible)


=========================================================================================       
C1.C1Pdf.dll Build Number 1.1.20034.4   Build Date: December 3, 2003 
========================================================================================= 

Enhancements/Documentation/Behavior Changes 
------------------------------------------- 
 * none

Corrections 
----------- 
 ** Fixed character spacing problem in Win9x (doesn't have GetCharWidth32)
 ** Fixed problem with localized decimal points in metafiles
 ** Fixed problem with hyperlink coordinates (rectangle wasn't being honored)
 ** Fixed problem with security permissions (AllowEditContent and AllowCopyContent were switched)


=========================================================================================       
C1.C1Pdf.dll Build Number 1.1.20034.3   Build Date: November 10, 2003 
========================================================================================= 

Enhancements/Documentation/Behavior Changes 
------------------------------------------- 
 * Added support for Embedded fonts (set FontType = FontTypeEnum.Embedded)

Corrections 
----------- 
 ** Fixed GDI leak related to font objects and GetReferenceGraphics()


1.1.20034.2 - October 17
	Fixed problem with bullets in RTF text
1.1.20034.1 - October 9
	First release

----------------------------------------------------------------------
Introduction
----------------------------------------------------------------------

C1Pdf supports most of the advanced features included in the PDF 
specification, including security, compression, outlining, hyperlinking, 
and file attachments.

But the main feature in C1Pdf is ease of use. The commands provided for 
adding content to documents are similar to the ones available in the 
.NET Graphics class. If you know how to display text and graphics in 
.NET, you already know how to use C1Pdf.

To create PDF documents using C1Pdf, three steps are required:
1) Create a C1PdfDocument object. 
2) Add content to the document. This usually involves calling the DrawString method.
3) Save the document to a file or to a stream using the Save method.

Here's how to create a "hello world" document using C1Pdf:

	// step 1: create the C1PdfDocument object
	C1.C1Pdf.C1PdfDocument pdf = new C1.C1Pdf.C1PdfDocument();

	// step 2: add content to the page
	RectangleF rc = pdf.PageRectangle;
	rc.Inflate(-72, -72);
	Font font = new Font("Arial", 12);
	pdf.DrawString("Hello World!", font, Brushes.Black, rc);

	// step 3: save the document to a file
	pdf.Save(@"c:\temp\hello world.pdf");
	
One important thing to remember is that C1Pdf uses a point-based coordinate 
system with the origin at the top-left corner of the page. This is similar 
to the default coordinate system used by .NET, but is different from the 
default PDF coordinate system (where the origin is on the bottom-left 
corner of the page).


