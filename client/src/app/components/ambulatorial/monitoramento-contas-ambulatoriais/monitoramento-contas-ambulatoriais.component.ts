import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-monitoramento-contas-ambulatoriais',
  templateUrl: './monitoramento-contas-ambulatoriais.component.html',
  styleUrls: ['./monitoramento-contas-ambulatoriais.component.css']
})
export class MonitoramentoContasAmbulatoriaisComponent implements OnInit {
  displayedColumns = ['local', 'valor', 'quantidade', 'Detalhes']

  constructor(private router: Router) { }

  ngOnInit(): void {
  }
  

}
