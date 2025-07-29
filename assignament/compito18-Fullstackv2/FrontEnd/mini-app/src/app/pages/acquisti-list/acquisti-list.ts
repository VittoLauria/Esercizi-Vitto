import { Component, OnInit } from '@angular/core';
import { Acquisto } from '../../api-client';
import {AcquistoService} from '../../api/acquisto.service';

@Component({
  selector: 'app-acquisti-list',
  imports: [],
  templateUrl: './acquisti-list.html',
  styleUrl: './acquisti-list.scss'
})
export class AcquistiList implements OnInit {
  acquisti: Acquisto[] = [];
  constructor(private svc: AcquistoService){}

  ngOnInit()
{
  this.svc.getAll().subscirbe((list: Acquisto[]) => this.acquisti = list);
}
}
