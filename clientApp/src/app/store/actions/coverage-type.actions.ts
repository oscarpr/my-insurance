import { Action } from '@ngrx/store';


export enum CoverageTypesActions {
    LOAD_COVERAGE_TYPES = '[COVERAGE TYPES] LOAD COVERAGE TYPES',
    LOAD_COVERAGE_TYPES_SUCCESS = '[COVERAGE TYPES] LOAD COVERAGE TYPES SUCCESS'
};

export class LoadCoverageTypes implements Action {
    public readonly type: string = CoverageTypesActions.LOAD_COVERAGE_TYPES;
}

export class LoadCoverageTypesSuccess implements Action {
    public readonly type: string = CoverageTypesActions.LOAD_COVERAGE_TYPES_SUCCESS;
    constructor(public playload: any) { }
}

export type CoverageTypes = LoadCoverageTypes | LoadCoverageTypesSuccess;
