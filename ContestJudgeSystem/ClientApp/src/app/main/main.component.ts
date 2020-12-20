import {Component} from '@angular/core';
import {FormArray, FormBuilder, Validators} from '@angular/forms';
import {MainService} from "./main.service";
import {CheckerEnum, Submission} from "../models/submission.model";
import {Language} from "../models/language.model";
import {Router} from "@angular/router";
import {NgxSpinnerService} from "ngx-spinner";

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  providers: [MainService]
})
export class MainComponent {

  public formGroup = this.fb.group({
    sourceCode: [null, Validators.required],
    lang: [1, Validators.required],
    files: this.fb.array( [this.initIO()]),
  });

  public languages: Language[];
  public selectedLang: Language;

  public readonly inputFlag = 0;
  public readonly outputFlag = 1;

  constructor(
    private fb: FormBuilder,
    private router: Router,
    private service: MainService,
    private spinner: NgxSpinnerService
  ) { }

  ngOnInit() {
    this.spinner.show();
    this.service.getLanguages().subscribe((languages: Language[]) => this.languages = languages)
      .add(() => this.spinner.hide());
  }

  initIO() {
    return this.fb.group({
      input: [null, Validators.required],
      inputSource: [],
      output: [null, Validators.required],
      outputSource: [],
    });
  }

  async onSubmit() {
    await this.spinner.show();
    let submission: Submission = {
      sourceCode: this.formGroup.value.sourceCode,
      languageId: this.formGroup.value.lang,
      files: this.formGroup.value.files.map(x => ({input: x.inputSource, output: x.outputSource})),
      checker: "",
      checkerType: CheckerEnum.Default,
    };
    this.service.sendSubmission(submission);
    await this.spinner.hide();
    await this.router.navigate(['/results']);
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
