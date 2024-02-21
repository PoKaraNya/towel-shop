import {Component, Input} from '@angular/core';
import {Category} from "../../shared/models/category";

@Component({
  selector: 'app-category-item',
  templateUrl: './category-item.component.html',
  styleUrl: './category-item.component.scss'
})
export class CategoryItemComponent {
  @Input() category?: Category | undefined;

  constructor() {
  }


}
