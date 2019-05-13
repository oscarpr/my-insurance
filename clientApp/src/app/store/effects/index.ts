import { CoverageTypeEffect } from './coverage-type.effects';
import { RiskTypeEffect } from './risk-type.effects';
import { PolicyEffect } from './policy.effects';


export const effects: any[] = [PolicyEffect, RiskTypeEffect, CoverageTypeEffect];

export * from './policy.effects';
export * from './risk-type.effects';
export * from './coverage-type.effects';