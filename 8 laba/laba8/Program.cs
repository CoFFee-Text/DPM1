using laba8;

var printer = new Printer();
var queue = new PrintQueue();
var logger = new Logger();
var dispatcher = new Dispatcher();

var mediator = new PrintSystemMediator(printer, queue, logger, dispatcher);

Document document1 = new Document("Eto document1.txt");
Document document2 = new Document("Ya ustal.docx");
Document document3 = new Document("Eshche odin document.pdf");
Document document4 = new Document("I eshche odin document 4.docx");

document1.SetMediator(mediator);
document2.SetMediator(mediator);
document3.SetMediator(mediator);
document4.SetMediator(mediator);

// --- Add to printing queue and print---
document1.AddToQueue();
dispatcher.CommandProcessQueue();

document2.AddToQueue();
dispatcher.CommandProcessQueue();

Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine("Print document with error");
Console.ResetColor();
printer.SimulateFailure = true;
document3.AddToQueue();
dispatcher.CommandProcessQueue();

Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine("Reset document after error");
Console.ResetColor();
document3.Reset();
dispatcher.CommandProcessQueue();

// --- Print a lot of documents in queue ---
document1 = new Document("Doc1.txt");
document2 = new Document("Doc2.txt");
document3 = new Document("Doc3.txt");
document4 = new Document("Doc4.txt");

document1.SetMediator(mediator);
document2.SetMediator(mediator);
document3.SetMediator(mediator);
document4.SetMediator(mediator);

document1.AddToQueue();
document2.AddToQueue();
document3.AddToQueue();
document4.AddToQueue();

Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine("Printing the entire queue:");
Console.ResetColor();

dispatcher.CommandProcessQueue(); 
dispatcher.CommandProcessQueue(); 
dispatcher.CommandProcessQueue(); 
dispatcher.CommandProcessQueue();


var doc = new Document("Test error doc.docx");

Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine("Printing attempt without adding to queue:");
Console.ResetColor();
doc.Print();

doc.AddToQueue();

Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine("An attempt to add the same document again:");
Console.ResetColor();
doc.AddToQueue();

dispatcher.CommandProcessQueue();

Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine("An attempt to reset an already printed document:");
Console.ResetColor();
doc.Reset();

Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine("Document states");
Console.ResetColor();

Document docStates = new Document("Nachalo.txt");

docStates.SetState(new PrintingState());
docStates.SetState(new DoneState());
docStates.SetState(new ErrorState());
docStates.SetState(new NewState());
