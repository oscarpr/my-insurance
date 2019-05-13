import { Action } from '@ngrx/store';

// Actions
export enum POLICY_ACTIONS {
    LOAD_POLICIES = '[POLICIES] LOAD_POLICIES',
    LOAD_POLICIES_SUCCESS = '[POLICIES] LOAD_POLICIES_SUCCESS',
    SAVE_POLICY = '[POLICIES] SAVE_POLICY',
    SAVE_POLICY_SUCCESS = '[POLICIES] SAVE_POLICY_SUCCESS',
    SAVE_POLICY_FAIL = '[POLICIES] SAVE_POLICY_FAIL',
    SAVE_POLICY_LOADING = '[POLICIES] SAVE_POLICY_LOADING',
    REMOVE_POLICY = '[POLICIES] REMOVE',
    REMOVE_POLICY_SUCCESS = '[POLICIES] REMOVE SUCCESS',
}

export class LoadPolicies implements Action {
    readonly type = POLICY_ACTIONS.LOAD_POLICIES;
}

export class LoadPoliciesSuccess implements Action {
    readonly type = POLICY_ACTIONS.LOAD_POLICIES_SUCCESS;
    constructor(public playload: any) { }
}

export class PoliciesLoading implements Action {
    readonly type = POLICY_ACTIONS.SAVE_POLICY_LOADING;
}

export class SavePolicy implements Action {
    readonly type = POLICY_ACTIONS.SAVE_POLICY;
    constructor(public playload: any) { }
}

export class SavePolicySuccess implements Action {
    readonly type = POLICY_ACTIONS.SAVE_POLICY_SUCCESS;
    constructor(public playload: any) { }
}

export class SavePolicyFail implements Action {
    readonly type = POLICY_ACTIONS.SAVE_POLICY_FAIL;
    constructor(public playload: any) { }
}

export class RemovePolicy implements Action {
    readonly type = POLICY_ACTIONS.REMOVE_POLICY;
    constructor(public playload: number) { }
}

export class RemovePolicySuccess implements Action {
    readonly type = POLICY_ACTIONS.REMOVE_POLICY_SUCCESS;
    constructor(public playload: number) { }
}

export type PolicyAction = LoadPolicies | PoliciesLoading | SavePolicy | SavePolicySuccess | SavePolicyFail | LoadPoliciesSuccess | RemovePolicySuccess;