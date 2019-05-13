import { Action } from '@ngrx/store';

export enum RISK_TYPES {
    LOAD_RISK_TYPES = '[RISK TYPES] LOAD RISK TYPES',
    LOAD_RISK_TYPES_SUCCESS = '[RISK TYPES] LOAD RISK TYPES SUCCESS'
};

export class LoadRiskTypes implements Action {
    public readonly type: string = RISK_TYPES.LOAD_RISK_TYPES;
    constructor() { }
}

export class LoadRiskTypesSuccess implements Action {
    public readonly type: string = RISK_TYPES.LOAD_RISK_TYPES_SUCCESS;
    constructor(public playload: any) { }
}

export type RiskType = LoadRiskTypes | LoadRiskTypesSuccess;
