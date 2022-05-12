// SECTION A
// 1. Create a class "Book" with a constructor that takes: title, author, and genre
class Book {
  constructor(title,author,genre){
    this.title = title;
    this.author = author;
    this.genre = genre;
  }


// 2. Create a class method for the Book class that returns formatted html in this form
  displayBookInfo() {
      var title_line = "<strong>Title: </strong>" + this.title + "<br>\n";
      var author_line = "<strong>Author: </strong>" + this.author + "<br>\n";
      var genre_line = "<strong>Genre: </strong>" + this.genre + "<hr>\n";
      return (title_line + author_line + genre_line);
  }
}

// SECTION B
// 1-4. This function prompts user to enter new book information
function addBook() {
  let title = prompt ('Please enter the title: ');
  let author = prompt ('Please enter the author: ');
  let genre = prompt ('Please enter the genre: ');
  return new Book(title, author, genre);
}

// Create the objects by asking user to input, q to quit
var myBooksArray = [];
alert ("Please enter a minimum of 3 books! ")
var z = 0;
while (true){
  let a = addBook();
  myBooksArray.push(a);
  z++;
  if (z >= 3) {
    quit = prompt ("Please enter 'q' to stop entering Book details");
    if (quit==='q')
      break;

  }
}
//   var quit = prompt ("Please enter 'q' to stop entering Book details");
//   if (quit==='q')
//     break;
// }

for(let book of myBooksArray){
  document.write(book.displayBookInfo());
}

document.querySelector('p').textContent = "You have " + z + " books! ";
// document.writeln("You have " + z + " books. ")
