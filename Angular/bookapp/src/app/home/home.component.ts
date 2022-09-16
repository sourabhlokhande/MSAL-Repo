import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { MsalService } from '@azure/msal-angular';
import { Books } from '../model/book.model';
import { BookService } from '../service/book.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  book : Books = 
  {
    title : '',
    genre : '',
    author: '',
    price : 0, 
    username : '',
    name : ''
  }

  books : Books[] = [];
  searchedKeyword : any = '';

  addBookForm : boolean= false;
  isUserLoggedIn():boolean
 {
   if(this.msalService.instance.getActiveAccount()!=null)
   {
    this.book.username = this.msalService.instance.getActiveAccount()?.username.toString(),
    this.book.name = this.msalService.instance.getActiveAccount()?.name?.toString()
     return true;
   }
   return false;
 }

  constructor(private bookService : BookService,private msalService:MsalService,private router :Router) { }

  ngOnInit(): void {
    this.getAllBooks();
  }

  showAddBook(): void{
    this.addBookForm = true;
 }


  getAllBooks()
  {
    this.bookService.getAllBooks()
    .subscribe(
      response => { 
        this.books = response;
      }); 
  }

  saved_btn : boolean = false;
  isValid : boolean = true;
  onSubmit()
  { 

    this.saved_btn = true;
    if(this.book.title!='')
    {
      this.bookService.addBook(this.book).subscribe();
    }
    else
    {
      this.isValid = false;
    }

    setTimeout(()=>{
      this.getAllBooks();
      this.saved_btn = false;
    },1000)
  }

  deleteBook(book : Books)
  {
    confirm("Are you Sure?")
    this.bookService.deleteBook(book);
    setTimeout(()=>{
      this.getAllBooks();
    },1000)
  }

  editbook(data:any)
  {
    if (data!=undefined && data!=null) {
      this.router.navigateByUrl('/update', { state: {data} });
    }
  }

}
