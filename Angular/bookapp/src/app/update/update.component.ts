import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Books } from '../model/book.model';
import { BookService } from '../service/book.service';

@Component({
  selector: 'app-update',
  templateUrl: './update.component.html',
  styleUrls: ['./update.component.css']
})
export class UpdateComponent implements OnInit {

  book : Books = 
  {
    title : '',
    genre : '',
    author: '',
    price : 0, 
    username : '',
    name : ''
  }

  item : any = null;
  constructor(private route: ActivatedRoute,private router:Router,private bookService : BookService) { 
    this.item = this.router.getCurrentNavigation()?.extras.state
  }
  
  ngOnInit(): void {}

  onSubmit()
  {
    this.bookService.updateBook(this.item.data).subscribe();
    setTimeout(()=>{
      this.router.navigateByUrl('/home');
    },1000)
  }

}
