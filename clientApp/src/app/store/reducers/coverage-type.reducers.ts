import * as fromCoverageType from '../actions/coverage-type.actions';

export interface IState {
    coverageTypes: any[];
    loading: boolean;
    loaded: boolean;
}

const initialState: IState = {
    coverageTypes: [],
    loading: false,
    loaded: false
}

export function reducer(state: IState = initialState, action: fromCoverageType.CoverageTypes): IState {
    switch (action.type) {
        case fromCoverageType.CoverageTypesActions.LOAD_COVERAGE_TYPES:
            return {
                ...state,
                loading: true,
                loaded: false
            };
        case fromCoverageType.CoverageTypesActions.LOAD_COVERAGE_TYPES_SUCCESS:
            return {
                coverageTypes: [...(action as fromCoverageType.LoadCoverageTypesSuccess).playload],
                loading: false,
                loaded: true
            };
        default:
            return { ...state }
    }
}

export const getCoverageTypes = (state: IState) => state.coverageTypes;
export const getCoverageLoading = (state: IState) => state.loading;
export const getCoverageLoaded = (state: IState) => state.loaded;
