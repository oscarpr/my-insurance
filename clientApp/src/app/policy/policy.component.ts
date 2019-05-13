import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';

import * as fromApp from '../store';
import { Observable } from 'rxjs';
import { FormGroup, FormBuilder, FormControl, FormArray } from '@angular/forms';
import { PolicyService } from './policy.service';

@Component({
  selector: 'app-policy',
  templateUrl: './policy.component.html',
  styleUrls: ['./policy.component.scss']
})
export class PolicyComponent implements OnInit {
  policies$: Observable<any[]>;
  riskTypes$: Observable<any[]>;
  coverageTypes$: Observable<any[]>;
  showForm: boolean;
  policyForm: FormGroup;

  constructor(private store: Store<fromApp.AppState>, private service: PolicyService, private fb: FormBuilder) {
    this.policies$ = store.select(fromApp.getPolicies);
    this.riskTypes$ = store.select(fromApp.getRiskTypes);
    this.coverageTypes$ = store.select(fromApp.getCoverageType);
    this.policyForm = service.getPolicyForm(fb);
  }

  ngOnInit() {
    this.loadPolicies();
    this.loadRiskTypes();
    this.loadCoverageTypes();
  }

  removePolicy(policyId: number): void {
    this.store.dispatch(new fromApp.RemovePolicy(policyId));
  }

  onChangeCoverageType(id: number, add: boolean) {
    let currentCoverages: any[] = [...this.policyForm.get('policyCoverage').value];
    if (add) {
      currentCoverages = [...currentCoverages, id];
    } else {
      currentCoverages = currentCoverages.filter((coverage: any) => coverage !== id);
    }
    const arrayInstances: FormControl[] = currentCoverages.map((coverageID: number) => new FormControl(coverageID));
    this.service.restartPolicyCoverage(this.policyForm);
    arrayInstances.forEach((control: FormControl, index: number) => {
      (<FormArray>this.policyForm.get('policyCoverage')).insert(index, control);
    });
  }

  onSubmit(policy: any) {
    this.store.dispatch(new fromApp.SavePolicy(policy));
    this.showForm = false;
    this.policyForm.reset();
  }

  private loadPolicies(): void {
    this.store.dispatch(new fromApp.LoadPolicies());
  }

  private loadRiskTypes(): void {
    this.store.dispatch(new fromApp.LoadRiskTypes());
  }

  private loadCoverageTypes(): void {
    this.store.dispatch(new fromApp.LoadCoverageTypes());
  }
}
