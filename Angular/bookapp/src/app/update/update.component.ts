import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Books } from '../model/book.model';

@Component({
  selector: 'app-update',
  templateUrl: './update.component.html',
  styleUrls: ['./update.component.css']
})
export class UpdateComponent implements OnInit {

  item : any = null;
  constructor(private route: ActivatedRoute,private router:Router) { 
    this.item = this.router.getCurrentNavigation()?.extras.state
  }
  
  ngOnInit(): void {}

  onSubmit()
  {
    console.log(this.item.data);
  }

}
