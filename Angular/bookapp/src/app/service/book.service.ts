import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Books } from "../model/book.model";

@Injectable({
    providedIn : 'root'
})

export class BookService
{
    
    baseUrl = 'https://localhost:7129/api/Book/'

    constructor(private http:HttpClient){}
    
    getAllBooks():Observable<Books[]>{
        return this.http.get<Books[]>(this.baseUrl+'GetBooks')
        
    }

    addBook(book: Books):Observable<Books>{
        return this.http.post<Books>(this.baseUrl+'AddBook', book)
    }

    deleteBook(book: Books) {
        return this.http.delete(this.baseUrl+"DeleteBook/"+book.bookId).subscribe(()=>{});
    }
}