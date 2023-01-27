/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { ProfessorService } from './professores.service';

describe('Service: Professores', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ProfessorService]
    });
  });

  it('should ...', inject([ProfessorService], (service: ProfessorService) => {
    expect(service).toBeTruthy();
  }));
});
