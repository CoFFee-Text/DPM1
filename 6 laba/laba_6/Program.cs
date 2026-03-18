using laba_6;

Console.WriteLine("--- Flyweight ---");
var charFactory = new CharacterFactory();
var char1 = charFactory.GetCharacter('F', "Times New Roman", 12);
var char2 = charFactory.GetCharacter('A', "Century Gothic", 12); 
Console.WriteLine($"Objects created: {charFactory.GetCount()}\n");



Console.WriteLine("--- Proxy ---");
IImage img1 = new ImageProxy("photka1.jpg");
IImage img2 = new ImageProxy("zhizn_zhiznennaya.png");

Console.WriteLine($"Width: {img1.GetWidth()}\n");

Console.WriteLine("Draw image:");
img2.Draw();



Console.WriteLine("--- Bridge ---");
IRenderingEngine screen = new ScreenRenderer();
IRenderingEngine printer = new PrintRenderer();

GraphicObject rect = new Rectangle(10, 20, 100, 50, screen);
GraphicObject ellipse = new Ellipse(30, 40, 25, 15, printer);
GraphicObject line = new Line(15, 14, 13, 12, screen);

rect.Draw();
ellipse.Draw();
line.Draw();



Console.WriteLine("--- Decorator ---");
IDrawable decorated = new BorderDecorator(rect, 3);
decorated = new ShadowDecorator(decorated, 10);
decorated = new TransparencyDecorator(decorated, 200);
decorated.Draw();