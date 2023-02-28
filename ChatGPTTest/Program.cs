using ChatGPTTest;

ChatGPT chat = new ChatGPT();

var movieName = await chat.GenerateText("Nome para filme de ação");
var movieImage = await chat.GenerateImage("Imagem para filme de ação");

Console.WriteLine(movieName);
Console.WriteLine(movieImage);