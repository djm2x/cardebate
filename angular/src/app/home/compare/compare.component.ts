import { Component, OnInit, EventEmitter, Output, Input } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { ModelService } from '../../admin/shared/model.service';
import { MarqueService } from '../../admin/shared/marque.service';
import { Model } from '../../shared/models';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-compare',
  templateUrl: './compare.component.html',
  styleUrls: ['./compare.component.scss']
})
export class CompareComponent implements OnInit {
  @Input() mainModel: Model;
  @Input() modelToCompare: Model;
  @Input() events: Observable<{ mainModel: Model, modelToCompare: Model }>;
  model = new Model();
  isThereComparable = false;
  constructor(private fb: FormBuilder, public service: ModelService
    , public serviceMrq: MarqueService) { }

  ngOnInit() {
    // new template
    this.calculate(this.mainModel, this.modelToCompare);
    // for old one
    // this.events.subscribe(r => this.calculate(r.mainModel, r.modelToCompare));
  }

  calculate(mainModel: Model, modelToCompare: Model) {
    if (!modelToCompare) {
      return;
    }
    this.isThereComparable = true;
    this.model.annee = mainModel.annee - modelToCompare.annee;
    this.model.puissance = mainModel.puissance - modelToCompare.puissance;
    this.model.reservoir = mainModel.reservoir - modelToCompare.reservoir;
    this.model.boiteVitesse = mainModel.boiteVitesse - modelToCompare.boiteVitesse;
    this.model.freinageUrgence = mainModel.freinageUrgence - modelToCompare.freinageUrgence;
    this.model.vitesseMax = mainModel.vitesseMax - modelToCompare.vitesseMax;
    this.model.poid = mainModel.poid - modelToCompare.poid;
    this.model.prix = mainModel.prix - modelToCompare.prix;
    this.model.autonomie = mainModel.autonomie - modelToCompare.autonomie;
    this.model.consVille = mainModel.consVille - modelToCompare.consVille;
    this.model.consRoute = mainModel.consRoute - modelToCompare.consRoute;
    this.model.consAutoroute = mainModel.consAutoroute - modelToCompare.consAutoroute;
    this.model.cc = mainModel.cc - modelToCompare.cc;
    this.model.consAutoroute = mainModel.consAutoroute - modelToCompare.consAutoroute;
    this.model.consAutoroute = mainModel.consAutoroute - modelToCompare.consAutoroute;
  }

  colorise(value: number) {
    if (!this.isThereComparable) {
      return { value: ``, color: '' };
    }
    let operator = '', color = 'brown';
    if (value >= 0) {
      operator = '+';
      color = 'green';
    }
    return { value: `${operator} ${value}`, color: color };
  }
}

class ModelExtended extends Model {
  note = 0;
  color = '';
}
