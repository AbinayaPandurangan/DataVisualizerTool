import MatchMediaMock from "jest-matchmedia-mock";
import { render, screen } from "@testing-library/react";
import { BrowserRouter } from "react-router-dom";
import App from "./App";
import "@testing-library/jest-dom";

let matchMedia;

describe("Your testing module", () => {
  beforeAll(() => {
    matchMedia = new MatchMediaMock();
  });

  afterEach(() => {
    matchMedia.clear();
  });

  test("Renders the HomePage heading", () => {
    render(
      <BrowserRouter>
        <App />
      </BrowserRouter>
    );
    const h1Element = screen.getByText("Data Visualizer");
    expect(h1Element).toBeInTheDocument();
  });
});
