import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UpdateProductListService {

  private observer = new Subject();
  public insertProductSubscriber$ = this.observer.asObservable();

  constructor() { }

  public updateList(): void {
    this.observer.next();
  }
}
