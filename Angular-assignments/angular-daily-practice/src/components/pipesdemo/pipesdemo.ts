import { DatePipe, LowerCasePipe, SlicePipe, TitleCasePipe, UpperCasePipe } from '@angular/common';
import { Component } from '@angular/core';
import { ReversePipe } from '../../app/pipes/reverse-pipe';

@Component({
  selector: 'app-pipesdemo',
  imports: [LowerCasePipe,UpperCasePipe,DatePipe,SlicePipe,TitleCasePipe,ReversePipe],
  templateUrl: './pipesdemo.html',
  styleUrl: './pipesdemo.css',
})
export class Pipesdemo {
  name:string="Goutham";

  datetoday:Date=new Date("10-09-2025")
}
