import { Component, EventEmitter, inject, Input, input, Output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Calculator } from '../../app/services/calculator';
import { MessageService } from '../../app/services/message-service';

@Component({
  selector: 'app-test',
  imports: [FormsModule],
  templateUrl: './test.html',
  styleUrl: './test.css',
})
export class Test {
  // Data binding
 
  // one way binding : 3 types
  // Interpolation
  name:string="Goutham"
  // Property binding
  imageUrl:string="https://images.pexels.com/photos/35195684/pexels-photo-35195684.jpeg"
  // Event binding
  showMessage()
  {
    console.log("the button is clicked !!")
  }

  // two way binding
  username = 'I am Goutham';



  private calculate=inject(Calculator);
  sum=this.calculate.add(2,5);
  subtract=this.calculate.subtract(5,4);


  private aos=inject(MessageService);
  
  getArrayData()
  {
    console.log(this.aos.getData());
  }
  AddStringToArray()
  {
    this.aos.addData("Goutham");
    console.log(this.aos.getData());
  }


  testname = input<string>();
  // @Input() testname!:string;

 
  @Output() dataChanged=new EventEmitter<string>();
  sendDataToParent(data:string)
  {
    this.dataChanged.emit(data);
  }
}
