import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { GeographicalDataItem } from '../Interfaces/GeographicalDataItem';
import { GeographicalDataService } from '../Services/geographicaldata.service';
import { delay } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  public geographicalDataItems: GeographicalDataItem[] = [];
  filteredGeographicalDataItems: GeographicalDataItem[] = [];
  selectedItem: GeographicalDataItem | null = null;
  showForm = false;

  searchText: string = '';
  sortField: keyof GeographicalDataItem | null = null;
  sortAsc: boolean = true;

  constructor(private geographicalService: GeographicalDataService) {}

  ngOnInit() {
    setTimeout(() => {
      this.getGeographicalData();
    }, 2000); // ff voor nu, in het echt had ik dit anders gedaan maar anders heb een error bij eerste launch
  }

  getGeographicalData() {
    this.geographicalService.getAll().subscribe({
      next: data => {
        this.geographicalDataItems = data
        this.filteredGeographicalDataItems = [...data];
        if (this.searchText) this.applyFilter();
      },
      error: err => {
        console.error("failed to fetch items.", err);
      }
    });
  }

  refreshTable() {
    this.getGeographicalData();
  }

  addEntry() {
    this.selectedItem = null;
    this.showForm = true;
  }

  updateEntry(index: number) {
    this.selectedItem = this.geographicalDataItems[index];
    this.showForm = true;
  }

  deleteEntry(index: number) {
    this.geographicalService.delete(this.geographicalDataItems[index].id).subscribe({
      next: () => this.refreshTable(),
      error: err => {
        console.error("failed to delete items.", err);
      }
    });
  }

  handleSave(item: GeographicalDataItem): void {
    if (item.id === 0) {
      this.geographicalService.add(item).subscribe(() => this.refreshTable());
    } else
    {
      this.geographicalService.update(item.id, item).subscribe(() => this.refreshTable());
    }
    this.showForm = false;
  }

  applyFilter() {
    const text = this.searchText.toLowerCase();
    this.filteredGeographicalDataItems = this.geographicalDataItems.filter(item =>
      Object.values(item).some(val =>
        val?.toString().toLowerCase().includes(text)
      )
    );
    if (this.sortField) {
      this.sortBy(this.sortField, false);
    }
  }

  sortBy(field: keyof GeographicalDataItem, toggle: boolean = true) {
    if (toggle) {
      this.sortAsc = this.sortField === field ? !this.sortAsc : true;
    }
    this.sortField = field;
    this.filteredGeographicalDataItems.sort((a, b) => {
      const aVal = a[field] ?? '';
      const bVal = b[field] ?? '';
      if (aVal < bVal) return this.sortAsc ? -1 : 1;
      if (aVal > bVal) return this.sortAsc ? 1 : -1;
      return 0;
    });
  }

  handleCancel(): void {
    this.showForm = false;
  }



  title = 'invennaopdracht.client';
}
