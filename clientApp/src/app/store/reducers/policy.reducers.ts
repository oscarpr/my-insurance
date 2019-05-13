import *  as fromAction from '../actions/policy.actions';

export interface IState {
    policies: any[],
    loaded: boolean,
    loading: boolean
}

const initialState: IState = {
    policies: [],
    loaded: false,
    loading: false
}

export function reducer(state: IState = initialState, action: fromAction.PolicyAction): IState {
    switch (action.type) {
        case fromAction.POLICY_ACTIONS.LOAD_POLICIES:
            return {
                ...state,
                loading: true,
                loaded: false
            }
        case fromAction.POLICY_ACTIONS.LOAD_POLICIES_SUCCESS:
            return {
                policies: [...action.playload],
                loading: false,
                loaded: true
            }
        case fromAction.POLICY_ACTIONS.REMOVE_POLICY_SUCCESS:
            const policyId: number = action.playload;
            return {
                policies: state.policies.filter((policy) => policy.id !== policyId),
                loading: false,
                loaded: true
            }
        case fromAction.POLICY_ACTIONS.SAVE_POLICY_SUCCESS:
            const newPolicy: any = { ...action.playload };
            return {
                policies: [...state.policies, newPolicy],
                loaded: true,
                loading: false
            }

        default:
            return { ...state };
    }
}

export const getPolicies = (state: IState) => state.policies;
export const getPoliciesLoading = (state: IState) => state.loading;
export const getPoliciesLoaded = (state: IState) => state.loaded;
