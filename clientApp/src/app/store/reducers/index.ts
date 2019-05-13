import * as fromPolicy from './policy.reducers';
import * as fromRiskType from './risk-types.reducers';
import * as fromCoverageType from './coverage-type.reducers';

import { ActionReducerMap } from '@ngrx/store';

export interface AppState {
    policy: fromPolicy.IState,
    riskType: fromRiskType.IState,
    coverageType: fromCoverageType.IState
}

export const reducers: ActionReducerMap<AppState> = {
    policy: fromPolicy.reducer,
    riskType: fromRiskType.reducer,
    coverageType: fromCoverageType.reducer
};
