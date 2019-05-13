import { environment } from './../../../environments/environment';
import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { Effect, Actions, ofType } from '@ngrx/effects';
import { switchMap, map, catchError } from 'rxjs/operators';

import * as fromPolicy from '../../store/actions/policy.actions';
import { of } from 'rxjs';

@Injectable()
export class PolicyEffect {

    private readonly policyUrl: string = `${environment.base}policy/`;

    constructor(private http: HttpClient, private action$: Actions) { }

    @Effect()
    loadPolicies = this.action$.pipe(
        ofType(fromPolicy.POLICY_ACTIONS.LOAD_POLICIES),
        switchMap(() => {
            return this.http.get(this.policyUrl)
                .pipe(
                    map((response: any) => new fromPolicy.LoadPoliciesSuccess(response)),
                    catchError((error: any) =>
                        of(new fromPolicy.SavePolicyFail(error))
                    )
                );
        })
    );

    @Effect()
    removePolicy = this.action$.pipe(
        ofType(fromPolicy.POLICY_ACTIONS.REMOVE_POLICY),
        switchMap((action: fromPolicy.RemovePolicy) => {
            return this.http.delete(`${this.policyUrl + action.playload}`)
                .pipe(
                    map(() => new fromPolicy.RemovePolicySuccess(action.playload))
                );
        })
    );

    @Effect()
    addPolicy = this.action$.pipe(
        ofType(fromPolicy.POLICY_ACTIONS.SAVE_POLICY),
        switchMap((action: fromPolicy.SavePolicy) => {
            return this.http.post(this.policyUrl, action.playload)
                .pipe(
                    map(() => new fromPolicy.LoadPolicies())
                );
        })
    );

}

