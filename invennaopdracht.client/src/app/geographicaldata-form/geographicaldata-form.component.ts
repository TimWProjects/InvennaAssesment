import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { GeographicalDataItem } from '../../Interfaces/GeographicalDataItem';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-geographicaldata-form',
  templateUrl: './geographicaldata-form.component.html',
  styleUrl: './geographicaldata-form.component.css'
})
export class GeographicaldataFormComponent implements OnInit {
  @Input() data?: GeographicalDataItem | null;
  @Output() save = new EventEmitter<GeographicalDataItem>();
  @Output() cancel = new EventEmitter<void>();

  form!: FormGroup;

  constructor(private fb: FormBuilder) { }

    ngOnInit(): void {
      this.form = this.fb.group({
        openbareRuimte: [this.data?.openbareRuimte || '', Validators.required],
        huisnummer: [this.data?.huisnummer || 0, Validators.required],
        huisLetter: [this.data?.huisLetter || ''],
        huisNummerToevoeging: [this.data?.huisNummerToevoeging || null],
        postcode: [this.data?.postcode || '', Validators.required],
        woonplaats: [this.data?.woonplaats || '', Validators.required],
        gemeente: [this.data?.gemeente || '', Validators.required],
        provincie: [this.data?.provincie || '', Validators.required],
        nummerAanduiding: [this.data?.nummerAanduiding || '', Validators.required],
        verblijfsobjectGebruiksdoel: [this.data?.verblijfsobjectGebruiksdoel || '', Validators.required],
        oppervlakteVerblijfsobject: [this.data?.oppervlakteVerblijfsobject || 0],
        verblijfsobjectStatus: [this.data?.verblijfsobjectStatus || '', Validators.required],
        object_Id: [this.data?.object_Id || '', Validators.required],
        object_Type: [this.data?.object_Type || '', Validators.required],
        nevenAdres: [this.data?.nevenAdres || '', Validators.required],
        pandId: [this.data?.pandId || '', Validators.required],
        pandStatus: [this.data?.pandStatus || '', Validators.required],
        pandBouwjaar: [this.data?.pandBouwjaar || 0],
        x: [this.data?.x || 0],
        y: [this.data?.y || 0],
        lon: [this.data?.lon || 0],
        lat: [this.data?.lat || 0],
      });
    }

  onSubmit(): void {
    if (this.form.valid) {
      const item: GeographicalDataItem = {
        id: this.data?.id ?? 0,
        ...this.form.value
      };
        this.save.emit(item);
    }
  }

  onCancel(): void {
    this.cancel.emit();
  }

  getInputType(fieldKey: string): string {
    const value = this.form.get(fieldKey)?.value;
    return typeof value === 'number' ? 'number' : 'text';
  }
}
