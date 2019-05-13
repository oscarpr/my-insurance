import { HttpClient } from '@angular/common/http';
import { Actions, Effect, ofType } from '@ngrx/effects';
import { Injectable } from "@angular/core";

import * as fromRiskType from './../actions/risk-type.actions';
import { switchMap, map, catchError } from 'rxjs/operators';
import { environment } from 'src/environments/environment';

@Injectable()
export class RiskTypeEffect {
    private readonly riskTypeURL: string = `${environment.base}risk-types`;

    constructor(private actions$: Actions, private http: HttpClient) { }

    @Effect()
    loadRiskType = this.actions$.pipe(
        ofType(fromRiskType.RISK_TYPES.LOAD_RISK_TYPES),
        switchMap(() => {
            return this.http.get(this.riskTypeURL)
                .pipe(
                    map((response: any) => new fromRiskType.LoadRiskTypesSuccess(response))
                );
        })
    );
}

