using Rpm_Lab5;
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        IRenderingEngine screenRenderer = new ScreenRenderer();
        Document document = new Document(screenRenderer);
        Page page1 = document.CreatePage();
        page1.Add(new Rectangle(screenRenderer, 10, 20, 100, 50));
        page1.Add(new Ellipse(screenRenderer, 150, 30, 40, 25));
        page1.Add(new Line(screenRenderer, 200, 50, 300, 80));

        var rectangle = new Rectangle(screenRenderer, 50, 60, 80, 40);
        IDrawable decoratedRectangle = new BorderDecorator(rectangle, 5);
        decoratedRectangle = new ShadowDecorator(decoratedRectangle);
        decoratedRectangle = new TransparencyDecorator(decoratedRectangle, 0.7);
        page1.Add(decoratedRectangle);

        IImage proxyImage = new ImageProxy("photo.jpg");
        page1.Add((IDrawable)proxyImage);
        Console.WriteLine($"Размер изображения: {proxyImage.GetWidth()}x{proxyImage.GetHeight()} px");

        Page page2 = document.CreatePage();
        CharacterFactory factory = new CharacterFactory();
        var charA = factory.GetCharacter('A', "Arial", 12);
        var charB = factory.GetCharacter('B', "Times", 14);
        var charC = factory.GetCharacter('C', "Arial", 12);
        var reusedA = factory.GetCharacter('A', "Arial", 12);
        Console.WriteLine($"\n Всего создано уникальных символов: {factory.GetCount()}");
        charA.Draw(10, 10);
        charB.Draw(30, 10);
        charC.Draw(50, 10);
        reusedA.Draw(70, 10);
        page2.Add(new CharacterDrawable(charA, 10, 10));
        page2.Add(new CharacterDrawable(charB, 30, 10));
        page2.Add(new CharacterDrawable(charC, 50, 10));
        page2.Add(new CharacterDrawable(reusedA, 70, 10));
        Console.WriteLine("\n" + new string('=', 50));
        Console.WriteLine("Рендеринг всего документа:");
        Console.WriteLine(new string('=', 50));
        document.RenderAll();

        Console.WriteLine("\n" + new string('=', 50));
        Console.WriteLine(new string('=', 50));

        IRenderingEngine printRenderer = new PrintRenderer();
        Document printDocument = new Document(printRenderer);
        Page printPage = printDocument.CreatePage();

        printPage.Add(new Rectangle(printRenderer, 10, 20, 100, 50));
        printPage.Add(new Ellipse(printRenderer, 150, 30, 40, 25));

        printDocument.RenderAll();
    }
}

public class CharacterDrawable : IDrawable
{
    private IFlyweight _character;
    private int _x, _y;

    public CharacterDrawable(IFlyweight character, int x, int y)
    {
        _character = character;
        _x = x;
        _y = y;
    }

    public void Draw()
    {
        _character.Draw(_x, _y);
    }
}
