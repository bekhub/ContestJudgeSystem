import {Component} from '@angular/core';
import {Validators, FormArray, FormBuilder} from '@angular/forms';
import {MainService} from "./main.service";
import {Submission} from "../models/submission.model";
import {Language} from "../models/language.model";
import {Router} from "@angular/router";

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  providers: [MainService]
})
export class MainComponent {

  public formGroup = this.fb.group({
    sourceCode: [null, Validators.required],
    lang: [0, Validators.required],
    files: this.fb.array( [this.initIO()]),
  });

  public languages: Language[];

  public readonly inputFlag = 0;
  public readonly outputFlag = 1;

  constructor(
    private fb: FormBuilder,
    private router: Router,
    private service: MainService
  ) { }

  ngOnInit() {
    this.service.getLanguages().subscribe((languages: Language[]) => this.languages = languages);
  }

  initIO() {
    return this.fb.group({
      input: [null, Validators.required],
      inputSource: [],
      output: [null, Validators.required],
      outputSource: [],
    });
  }

  onSubmit() {
    let submission: Submission = {
      sourceCode: this.formGroup.value.sourceCode,
      languageId: this.formGroup.value.lang,
      files: this.formGroup.value.files.map(x => ({input: x.inputSource, output: x.outputSource})),
    };
    this.service.sendSubmission(submission).subscribe(
      () => this.router.navigate(['/result']),
      error => console.log(error)
    );
  }

  onFileChanged(event: any, index: number, flag: number) {
    if (event.target.files && event.target.files.length) {
      const [file] = event.target.files;
      this.files.at(index).patchValue(flag == this.inputFlag
          ? {inputSource: file}
          : {outputSource: file});
    }
  }

  addIO() {
    this.files.push(this.initIO());
  }

  removeIO(index: number) {
    this.files.removeAt(index);
  }

  get files() {
    return this.formGroup.get('files') as FormArray;
  }
}
