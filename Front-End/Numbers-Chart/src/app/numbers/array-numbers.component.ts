import { templateSourceUrl } from '@angular/compiler';
import { Component, OnInit} from '@angular/core';
import { ArrayNumber } from '../models/array-numbers.model';
import {HttpClient} from '@angular/common/http';

@Component({
    selector: 'array-numbers',
    templateUrl: './array-numbers.component.html',
    styleUrls: ['./array-numbers.component.css']
})

export class ArrayNumbersComponent implements OnInit{
    li:any; 
    arrayNumbers: ArrayNumber[]

    verticalPoints: number[] =Array.from(Array(26).keys())
    
    constructor(private http : HttpClient){
        this.http.get<ArrayNumber[]>('http://localhost:60170/ArrayNumber').subscribe(Response => { 
           console.log(Response) 
            this.arrayNumbers=Response; 
          });
    }

    ngOnInit(){
    }
      
    
    getHeight(number) {
        return number*28;
      }
}
