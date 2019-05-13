import { FormGroup, FormBuilder, Validators, FormArray } from '@angular/forms';
import { Injectable } from "@angular/core";


@Injectable()
export class PolicyService {

    constructor() { }

    getPolicyForm(fb: FormBuilder): FormGroup {
        let form: FormGroup = fb.group({
            name: [null, [Validators.required]],
            description: [null, [Validators.required]],
            percentage: [null, [Validators.required, Validators.pattern(/^[0-9]*$/)]],
            initDate: [null, Validators.required],
            coverageTime: [null, [Validators.required, Validators.pattern(/^[0-9]*$/)]],
            price: [null, [Validators.required, Validators.pattern(/^[0-9]*$/)]],
            riskTypeID: [null, Validators.required],
            policyCoverage: fb.array([])
        });
        return form;
    }

    restartPolicyCoverage(form: FormGroup): void {
        const arrayLength: number = (<FormArray>form.get('policyCoverage')).controls.length;
        for (let i = arrayLength; i >= 0; i--) {
            (form.get('policyCoverage') as FormArray).removeAt(i);
        }
    }
}
