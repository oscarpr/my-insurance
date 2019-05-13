import { HttpClient } from '@angular/common/http';
import { Actions, Effect, ofType } from '@ngrx/effects';
import { Injectable } from '@angular/core';

import * as fromCoverageTypes from '../actions';
import { switchMap, map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';


@Injectable()
export class CoverageTypeEffect {
    private readonly coverageTypeUrl: string = `${environment.base}coverage-types`;

    constructor(private actions$: Actions, private http: HttpClient) { }

    @Effect()
    loadCoverageTypes = this.actions$.pipe(
        ofType(fromCoverageTypes.CoverageTypesActions.LOAD_COVERAGE_TYPES),
        switchMap(() => {
            return this.http.get(this.coverageTypeUrl)
                .pipe(
                    map((response: any) => new fromCoverageTypes.LoadCoverageTypesSuccess(response))
                );
        })
    );
}

