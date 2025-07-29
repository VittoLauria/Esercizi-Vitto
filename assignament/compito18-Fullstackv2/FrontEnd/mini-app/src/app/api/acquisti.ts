import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class Acquisti {
    constructor(private api: ApiClient){}

   acquistoAll(): Observable<AcquistoDTO[]> {
    return this.processAcquistoAll(response_);
}
    acquistoPOST(body?: Acquisto | undefined): Observable<void> {
  return this.processAcquistoPOST(response_);
}
 acquistoGET(id: number): Observable<Acquisto> {   
  return this.http.request("get", url_, options_).pipe(_observableMergeMap((response_ : any) => {
             return this.processAcquistoGET(response_);
  }
   acquistoDELETE(id: number): Observable<void> {
      return this.processAcquistoDELETE(response_);
   }
 }
}
