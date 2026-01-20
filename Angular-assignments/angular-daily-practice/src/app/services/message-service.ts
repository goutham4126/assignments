import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class MessageService {
    private aos:string[]=["Ramesh","Suresh","Ganesh","Parmesh"]
    getData()
    {
       return this.aos;
    }

    addData(s:string)
    {
      this.aos.push(s);
    }
}
