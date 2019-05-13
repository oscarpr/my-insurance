import * as fromApp from '../reducers';
import * as fromPolicy from '../reducers/policy.reducers';
import { createSelector } from '@ngrx/store';

const selectState = (state: fromApp.AppState) => state.policy;


export const getPolicies = createSelector(
    selectState,
    fromPolicy.getPolicies
);

export const getPoliciesLoaded = createSelector(
    selectState,
    fromPolicy.getPoliciesLoaded
);
export const getPoliciesLoading = createSelector(
    selectState,
    fromPolicy.getPoliciesLoading
);
