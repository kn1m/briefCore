using System;

namespace briefCore.Tesseract.Console
{
    using Console = System.Console;

    class Program
    {
        static void Main(string[] args)
        {
            string result = String.Empty;
            
            using (var engine = new TesseractEngine("../../../tessdata", "ukr", EngineMode.Default))
                {
                    using (var img = Pix.LoadFromFile("1.tiff"))
                    {
                        using (var page = engine.Process(img))
                        {
                            var text = page.GetText();
                            Console.WriteLine("Mean confidence: {0}", page.GetMeanConfidence());

                            //result += text;

                            using (var iter = page.GetIterator())
                            {
                                iter.Begin();

                                do
                                {
                                    do
                                    {
                                        do
                                        {
                                            do
                                            {
                                                if (iter.IsAtBeginningOf(PageIteratorLevel.Block))
                                                {
                                                    result += Environment.NewLine;
                                                }

                                                result += iter.GetText(PageIteratorLevel.Word);
                                                result += " ";

                                                if (iter.IsAtFinalOf(PageIteratorLevel.TextLine, PageIteratorLevel.Word))
                                                {
                                                    result += Environment.NewLine;
                                                }
                                            } while (iter.Next(PageIteratorLevel.TextLine, PageIteratorLevel.Word));

                                            if (iter.IsAtFinalOf(PageIteratorLevel.Para, PageIteratorLevel.TextLine))
                                            {
                                                result += Environment.NewLine;
                                            }
                                        } while (iter.Next(PageIteratorLevel.Para, PageIteratorLevel.TextLine));
                                    } while (iter.Next(PageIteratorLevel.Block, PageIteratorLevel.Para));
                                } while (iter.Next(PageIteratorLevel.Block));
                            }
                        }
                    }
                }
            
            Console.WriteLine(result);
        }
    }
}