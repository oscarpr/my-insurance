import * as fromAppState from '../reducers';
import * as fromCoverageType from '../reducers/coverage-type.reducers';
import { createSelector } from '@ngrx/store';


const selectState = (state: fromAppState.AppState) => state.coverageType;


export const getCoverageType = createSelector(
    selectState,
    fromCoverageType.getCoverageTypes
);
export const getCoverageTypeLoading = createSelector(
    selectState,
    fromCoverageType.getCoverageLoading
);
export const getCoverageTypeLoaded = createSelector(
    selectState,
    fromCoverageType.getCoverageLoaded
);
