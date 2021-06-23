import { TemplateRef } from '@angular/core';
import { Component, OnInit, Input } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-sinaleiras',
  templateUrl: './sinaleiras.component.html',
  styleUrls: ['./sinaleiras.component.css']
})
export class SinaleirasComponent implements OnInit {
  modalRef: BsModalRef;
  items: any[];

  @Input() status: string;

  constructor(private modalService: BsModalService) {
    this.items = Array(3).fill(0);
  }
 
  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template);
  }
  ngOnInit(): void { }
}
