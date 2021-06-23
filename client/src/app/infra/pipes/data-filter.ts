import { Pipe, PipeTransform } from "@angular/core";
import { DatePipe } from '@angular/common';



@Pipe({
    name: 'converterdata'
})

export class ConverterDataPipe implements PipeTransform{

    constructor(private datePipe: DatePipe){
    }

    transform(data: string) {
        let dataFormatada = data == "0001-01-01T00:00:00" ? "" : this.datePipe.transform(data, "dd/MM/yyyy");
        return dataFormatada
    }
}