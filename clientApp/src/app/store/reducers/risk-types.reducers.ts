import * as fromRiskType from './../actions/risk-type.actions';

export interface IState {
    riskTypes: any[];
    loaded: boolean;
    loading: boolean
}

const initialState: IState = {
    riskTypes: [],
    loaded: false,
    loading: false
}

export function reducer(state: IState = initialState, action: fromRiskType.RiskType): IState {
    switch (action.type) {
        case fromRiskType.RISK_TYPES.LOAD_RISK_TYPES:
            return {
                ...state,
                loading: true,
                loaded: false
            }
        case fromRiskType.RISK_TYPES.LOAD_RISK_TYPES_SUCCESS:
            return {
                riskTypes: [...(action as fromRiskType.LoadRiskTypesSuccess).playload],
                loading: false,
                loaded: true
            }
        default:
            return { ...state }
    }
}

export const getRiskTypes = (state: IState) => state.riskTypes;
export const getRiskTypeLoaded = (state: IState) => state.loaded;
export const getRiskTypeLoading = (state: IState) => state.loading;
