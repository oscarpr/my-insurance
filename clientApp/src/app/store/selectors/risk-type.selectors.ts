import * as fromApp from '../reducers';
import * as fromRiskTypes from '../reducers/risk-types.reducers';
import { createSelector } from '@ngrx/store';


const selectState = (state: fromApp.AppState) => state.riskType;

export const getRiskTypes = createSelector(
    selectState,
    fromRiskTypes.getRiskTypes
);

export const getRiskTypesLoaded = createSelector(
    selectState,
    fromRiskTypes.getRiskTypeLoaded
);

export const getRiskTypeLoading = createSelector(
    selectState,
    fromRiskTypes.getRiskTypeLoading
);
